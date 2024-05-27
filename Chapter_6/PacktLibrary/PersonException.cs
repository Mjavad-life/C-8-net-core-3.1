using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// اینجا میخواد به جای تعریف یک تایپ جدید
/// داره استفاده کنه .NET از همون هایی که
/// و از اونها ارث بری کنه
/// </summary>
/// <summary>
/// استفاده بشه base constroctur ها ارث بری ندارند پس باید از  constructor
/// </summary>
namespace Packt.Shared
{   
    public class PersonException : Exception
    {      
        public PersonException() : base() { }

        public PersonException (string message) : base(message) {}

        public PersonException(string message , Exception innerException)
            : base(message , innerException) { }
    }
}