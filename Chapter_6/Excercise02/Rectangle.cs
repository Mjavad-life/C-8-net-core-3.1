namespace Mojgan
{
    public class Rectangle : Shape
    {   
        public Rectangle(double height , double width)
        {   
            //  این فیلدها رو خارج از متد کانستراکت یا متد های دیگه
            // که تعریف میکنیم نشون نمیده 
            Height = height;
            Width = width;
            Area = (Height + Width) * 2;
        }
        
        public void calc()
        {   
            // گرچه این یک متد الکیه
            // اینجا هم به سه فیلد دسترسی میده
            Height = 0;
            Width = 0;
            Area = 0;
        }
        
    }
}