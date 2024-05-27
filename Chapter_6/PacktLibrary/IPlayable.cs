using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

/// <summary>
/// ساختم Interface اینجا یک 
/// new c# interface بوسیله 
/// </summary>
namespace Packt.Shared
{   
    public interface IPlayable
    {
        void Play();

        void Pause();

        void Stop()
        {
            WriteLine("Default piade bazi berey stop");
        }
    }
}