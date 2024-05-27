using Packt;
using System;
using Xunit;

namespace PacktUnitTests
{
    public class ManCityUnitTests
    {
        [Fact]
        public void TestAdding2And2()
        {
                //arrange
                double a = 2;
                double b = 2;
                double expected = 4;

                var new_mancity = new ManCity();

                // act
                double actual = new_mancity.Add(a , b);

                //assert
                Assert.Equal(expected , actual);
        }
         [Fact]
        public void TestAdding2And3()
        {
                //arrange
                double a = 2;
                double b = 3;
                double expected = 6;

                var new_mancity = new ManCity();

                // act
                double actual = new_mancity.Add(a , b);

                //assert
                Assert.Equal(expected , actual);
        }
    }
}