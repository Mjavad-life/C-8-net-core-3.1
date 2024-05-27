using System;

namespace SerializationXML
{
    public class Rectangle:Shape
    {   
        public Rectangle(): base(){}

        public Rectangle(string color , double height , double width)
        {
            Color = color;
            Height = height;
            Width = width;
            Area = height * width;
        }
    }
}