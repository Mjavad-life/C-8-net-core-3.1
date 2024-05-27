using Microsoft.Extensions.Logging;
using System;
using static System.Console;

/// <summary>
///  در این کلاس میخواهد برای نشان دادن ارتباط
/// استفاده کند Logging  از  EF Core میان پایگاه داده و 
/// مراحل مختلف وصل شدن را نشان میدهد
/// </summary>
/// 
namespace Packt.Shared
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {   
        /// <summary>
        /// این تابع یک کنسول لاگر را بازمیگرداند
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }
        // اگر لاگر از منابع مودورویت نشده استف کنه
        // اینجوری حافظه رو آزاد موکونیم
        public void Dispose() {  }
    
    } // 

    public class ConsoleLogger : ILogger
    {   
        // اگر لاگر شما از منابع مودورویت نشده استف کنه ، 
        // را پیاده میکند باز گرداند IDispose میتوان کلاسی که 
       public IDisposable? BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {   
                // کنسول لاگر برای سه حالت زیر غیرفعال است
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            }
        }

       public void Log<TState>(LogLevel logLevel, EventId eventId, 
            TState state, Exception? exception, Func<TState, Exception?, 
            string> formatter)
        {   // است SQL شناسه 20100 مربوط به اجرای دستورات 
            if (eventId.Id == 20100)
            {
                
           // Write($"Sath: {logLevel}, Event ID: {eventId.Id}");
                Write("Level: {0}, Event ID: {1}, Event: {2}",
                    logLevel , eventId.Id, eventId.Name);
            
            // اگر حالت موجود بود آنرا نشان میدهد 
            if (state != null)
            {
                Write($", State: {state}");
            }
            if (exception !=null)
            {
                Write($", Exception: {exception.Message}");
            }
            WriteLine();
            }
        }
    }
}