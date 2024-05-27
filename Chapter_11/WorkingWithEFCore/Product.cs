using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// northwind جدول محصولات در پایگاه داده
/// </summary>
namespace Packt.Shared
{
    public class Product
    {   
        // هر خصوصیت زیر با نام یک ستون در جدول محصولات پایگاه داده منطبق است
        // داره یعنی کلید اصلی هسته ID اینجا که 
        public int ProductID { get; set; }        

        [Required]
        [StringLength(40)]
        public string? ProductName { get; set; }

        // نوشته شده ولی اینجی چوون فرق فوکوله money در متن کتاب 
        // نوشتم TypeName = "int"
        [Column("UnitPrice", TypeName = "int")]
        public int? Cost { get; set; }

        [Column("UnitsInStock")]
        // نوشته شده ولی اینجی چوون فرق فوکوله short در متن کتاب 
        // نوشتم int , Stock پشت
        public int? Stock { get; set; }

        public bool Discontinued { get; set; }

        // را تعریف میکنند Category این دو ارتباط کلید خارجی با جدول 
        public int CategoryID { get; set; }

        // کرد overridesh رو به شکل ویرچوال نوشته تا بشه  Category
        public virtual Category? Category { get; set; }
    }
}