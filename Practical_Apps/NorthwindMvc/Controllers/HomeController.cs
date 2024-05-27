using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;

namespace NorthwindMvc.Controllers
{   
    /// <summary>
    /// این کلاس به نام کنترولر مربوط به صفحه خانه و کدنویسی های
    /// مربوط به قسمت های مختلف آن است
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private NorthWind db;

        private readonly IHttpClientFactory clientFactory;

        /// <summary>
        /// در قسمت سازنده پایگاه داده باد شمال را وارد کردیم
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="injectedContext"></param>
        public HomeController(ILogger<HomeController> logger ,
            NorthWind injectedContext , IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            db = injectedContext;
            clientFactory = httpClientFactory;
        }

        /// <summary>
        /// این متد به صورت همزمان کار میکند
        /// و تعداد بازدیدکنندگان و محصولات و دسته
        /// بندی ها را محاسبه میکند
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {   
            var model = new HomeIndexViewModel
                {
                    VisitorCount = (new Random()).Next(1, 1001),
                    Categories   = await db.Categories.ToListAsync(),
                    Products     = await db.Products.ToListAsync()
                };
            return View(model); // مدل رو به ویو میفرسند
        }

        /// <summary>
        /// این تابع در اینجا کار خاصی ندارد
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// این تابع در صورت وجود خطا شماره فعالیت و پیام 
        /// مربوطه را نشان میدهد
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        /// <summary>
        /// این تابع اطلاعات مربوط به هر محصول
        /// را نشان میدهد که با کلیک روی محصول
        /// به نمایش درمی آید
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ProductDetail(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("you must pass a product ID in the route, for example, /Home/ProductDetail/21");
            }

            var model = await db.Products
                .SingleOrDefaultAsync(p => p.ProductID == id);

            if (model == null)
            {
                return NotFound($"Product with ID of {id} not found");
            }

            return View(model); // مدل رو به ویو میفرسته و نتیجه رو برمیگردونه
        }

        /// <summary>
        /// این تابع اطلاعات مربوط به هر دسته را نشان میدهد
        /// آنرا میبینیم view که با فشردن دکمه 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> CategoryDetail(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("you must pass a category ID in the route, for example, /Home/CategoryDetail/1");
            }

            var model = await db.Categories
                .SingleOrDefaultAsync(p => p.CategoryID == id);

            if (model == null)
            {
                return NotFound($"Category with ID of {id} not found");
            }

            return View(model);
        }

        public IActionResult ModelBinding()
        {
            return View(); // یک صفحه با فرمی برای پر کردن
        }

        [HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            // return View(thing); // مدل بوند تینگ را نمایش میدهد

            var model = new HomeModelBindingViewModel
            {
                Thing = thing ,
                HasErrors = !ModelState.IsValid ,
                ValidationErrors = ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage)
            };

            return View(model);
        }

        /// <summary>
        /// این تابع اطلاعات مربوط به محصولات با قیمت بیشتر
        /// از مبلغ مدنطر را نشان میدهد
        /// که با کلید ارسال فعال میشود
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
       /* public async Task<IActionResult> ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return NotFound("you must pass a قیمت کالا در رشته پرس و جو برای نمونه  /home/productsthatcostmorethan?price=50");
            }

            IEnumerable<Product> model = await db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .AsEnumerable() // سوییچ به سمت کاربر
                .Where(p => p.UnitPrice > price);

            if (model.Count() == 0)
            {
                return NotFound($"No products cost more than {price:C}.");
            }
            ViewData["MaxPrice"] = price.Value.ToString("C");

            return View(model); // مدل را به ویو میفرستد
        }
    */
        public async Task<IActionResult> Customers(string country)
        {
            string uri;
            if (string.IsNullOrEmpty(country))
            {
                ViewData["Title"] = "All Customers Worldwide";
                uri = "api/customers/";
            }
            else
            {
                ViewData["Title"] = $"Customers in {country}";
                uri = $"api/customers/?country={country}";
            }
            var client = clientFactory.CreateClient(name: "NorthwindService");
            var request = new HttpRequestMessage(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            IEnumerable<Customer> model = JsonConvert
            .DeserializeObject<IEnumerable<Customer>>(jsonString);
            
            return View(model);
        }
    }
}    