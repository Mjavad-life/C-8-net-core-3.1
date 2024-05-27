// dar in kelas az yek field be sorate static
// mikhahad use konad

using System;

/// <summary>
/// yek kelas digar be namespace ezafe mikonad dar morede hesab banki ta 
/// karbord static ra neshan dahad
/// </summary>
namespace Packt.Shared
{
    public class BankAccount
    {
        public string? AccountName;   // instance member
        public decimal Balance;      // instance member
        public static decimal InterestRate; // shared member 
    }
    
}