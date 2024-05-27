using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// هستندی northwind این جدول دسته بندی های پایگاه داده
/// عین همین جدول تو پایگاه داده بالا هست
/// </summary>
namespace Packt.Shared
{
    public class Category
    {
        // این خواص به ستون ها در پایگاه داده نگاشت میشندی   
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        // نوشته ولی من پایگاه داده ام یکم فرق داره و اونجا ntext در کتاب 
        // هست TypeName = "TEXT"
        [Column(TypeName = "text")]
        public string Description { get; set; }

        // تعرف یک خاصیت جهت یابی برای سطرهای مرتبطه
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            // برای اینکه برنامه نویسان را بتونونیم محصول اضافه کینن
            //می بایست خاصیت جهت یابی رو به یک لیست Category به 
            // خالی بیاغازونیم
            this.Products = new List<Product>();
        }
    }
}