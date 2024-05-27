using static System.Console;
using System.IO;

namespace SelectionStatements
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                WriteLine("there are no arguments");
            }
            else
            {
                WriteLine("there is at least one argument");
            }

            // aval o="3" badesh o=3
            object o = 3;
            int j = 4;
            if (o is int i) // inja o ro = i gharar mideh
            {
                WriteLine($"{i} x {j} = {i * j}");
            }
            else
            {
                WriteLine("o is not an int so it cannot multiply");
            }

            A_label:
                var number = (new Random()).Next(1,7);
                WriteLine($" my random number is {number}");

                switch (number)
                {
                    case 1:
                        WriteLine("one");
                        break; // jumps to end of switch statement
                    case 2:
                        WriteLine("two");
                        goto case 1;
                    case 3:
                    case 4:
                        WriteLine("three or four");
                        goto case 1;
                    case 5:
                        // go to sleep for half a second
                        System.Threading.Thread.Sleep(2000);
                        goto A_label;
                    default:
                        WriteLine("default");
                        break;
                    
                } // end of switch statement

            // string path = "\users\markjprice\code\chapter03
            string path = @"D:\Code\Chapter_3";

            Stream s = File.Open(
            // yek file be nam file.txt misazad
                    
            Path.Combine(path, "file.txt") , FileMode.OpenOrCreate);

            string message = string.Empty;

            switch (s)
            {
                // chon filemode open or create ast pas can write mishavad
                case FileStream writeableFile when s.CanWrite:
                    message = "the stream is a file that i can write to.";
                    break;
                case FileStream readOnlyFile:
                    message = "the stream is a read-only file.";
                    break;
                case MemoryStream ms:
                    message = "the stream is a memory address.";
                    break;
                default: // always evaluated last despite its current position
                    message = "the stream is some other type.";
                    break;
                case null:
                    message = "the stream is null.";
                    break;
                }

                WriteLine(message);

                // کار با ساده شده ی سوییچ
                message = s switch 
                {
                    FileStream writeableFile when s.CanWrite
                        => " the stream is a file that i can write to.",
                    FileStream readOnlyFile
                        => "the stream is a read-only file.",
                    MemoryStream ms
                        => "the stream is a memory address.",
                    null
                        => "the stream is null.",
                    _
                        => "the stream is some other type."
                };

                WriteLine(message);


        }// end of Main method
    }
}