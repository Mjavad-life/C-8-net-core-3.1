using PrimaryLeague;
using System;
using Xunit;
using static System.Console;
using System.IO;
using static System.Convert;

/// <summary>
///  zaman neveshtan be tagheer esme  ManCityUnitTests.cs be ManCityUnitTests( bedone .cs) hasas bod
/// ye bar workspace ro bastam / baz kardam dorost shod
/// </summary>

namespace ManCityLibUnitTests
{
    public class ManCityUnitTests
    { 
        /// <summary>
        ///  here we test the ManCity class method named prime_factors()
        /// </summary>
        /// 
        [Fact]
        public void TestMancity()
        {
            // arrange  
            
            // dar inja tek adad ra baraye prime_factor kardan minevisim
           int adad_test = 1000 ;
           // yek list tarif mikonim ke betone motaghayer bashe
           List<string> expected = new List<string>() ;
           // roye kaghaz amal taghsim ro anjam dadam va javab morede
           // entezar ro be list ezafe kardam
            expected.Append("2");
            expected.Append("2");
            expected.Append("2");
            expected.Append("5");
            expected.Append("5");
            expected.Append("5");
            
            // yek instance az kelass man city misazim
            var NewManCity = new ManCity();

            //act
            List<string> actual = NewManCity.Prime_Factors(adad_test);            

            // assert
            // inja javabi ke az metod prime_factor miayad ra ba 
            // onche entezar darim moghayese mikonad
            Assert.Equal(expected , actual);
            
            
        } // payane method test
    } // akhare class prime_unit_test
} // end of mazrab_test