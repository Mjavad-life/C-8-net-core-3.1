using System;

namespace SerializationXML
{
    public class Circle : Shape
    {   
        public string Color {get ; set;}
        public double Radius {get; set;}
        public double Area {get; set;}

        public Circle() : base(){}

        public Circle(string color , double radius) 
        {
            Color = color;
            Radius = radius;
            Area = Radius * Radius;
            
        }
    }

}