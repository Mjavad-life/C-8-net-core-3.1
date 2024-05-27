using static System.Console;
using System.IO;
using static System.Convert;// mikhaim ke type haro be ham tabdil konim
using System.Diagnostics; // baraye use az debug va trace ezafe shod
using System.Threading.Tasks;
using System.IO; // mikhad ke trace dar yek text file be namayesh dar ayad
using Microsoft.Extensions.Configuration; // baraye kar ba switch trace

namespace Instrumenting
{
    public class Program
    {
        static void Main(string[] args)
        {  
            // write to a text file in the project folder
            // yek trace new ezafe mikone
            Trace.Listeners.Add(new TextWriterTraceListener(
                File.CreateText("log.txt")));

            // text writer is buffered , so this option calls
            // flush() on all listeners after writing
            Trace.AutoFlush = true;

            // az debug va trace baraye eib yabi use mikone
            // do khate zir dar debug console neshan dade mishavad
            Debug.WriteLine(" debug say , darom niga mokonom.");
            Trace.WriteLine(" trace says , moyom darom nazar mindazom.");

            // code haye zir baraye use az trace switch hast

            var builder = new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory()).
            // mire to file appsettings.json mifahme ke level info ast
            AddJsonFile("appsettings.json" , optional : true ,
            reloadOnChange : true);

            IConfigurationRoot configuration = builder.Build();

            var ts = new TraceSwitch(
                displayName: "PacktSwitch",
                description: "this switch is set via a json config"
            );

            configuration.GetSection("PacktSwitch").Bind(ts);

            Trace.WriteLineIf(ts.TraceError , "trace error");
            Trace.WriteLineIf(ts.TraceWarning , "trace warning");
            Trace.WriteLineIf(ts.TraceInfo , "trace information");
            Trace.WriteLineIf(ts.TraceVerbose , "trace verbose");

 
 
 
        }
    }
}