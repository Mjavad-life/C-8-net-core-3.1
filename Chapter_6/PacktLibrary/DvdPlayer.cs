using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Packt.Shared
{
    public class DvdPlayer : IPlayable
    {
        public void Pause()
        {
            WriteLine("DVD player pause shode.");
        }

        public void Play()
        {
            WriteLine("DVD Player dare mipakhshole.");
        }
    }
}