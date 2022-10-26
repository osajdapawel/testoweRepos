using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Test
{
    public class MetricBmiCalculatorTests
    {
        [Theory]
        [InlineData(100, 170, 34.6)]
        [InlineData(57, 170, 19.72)]
        [InlineData(70, 170, 24.22)]
        [InlineData(77, 160, 30.08)]
        public void CalculateBmi_ForGivenData_ReturnsCorrectBMI(double weight, double height, double expectedBMI)
        {
            // arrange
            MetricBmiCalculator calculator = new MetricBmiCalculator();

            // act
            var result = calculator.CalculateBmi(weight, height);

            // assert
            Assert.Equal(expectedBMI, result);
        }


        [Theory]
        [InlineData(0, 190)]
        [InlineData(10, 0)]
        [InlineData(-1, 30)]
        [InlineData(3, -10)]
        public void CalculateBmi_ForInvalidData_ThrowsAnException(double weight, double height)
        {
            // arrange
            MetricBmiCalculator calculator = new MetricBmiCalculator();

            // act
            Action action = () => calculator.CalculateBmi(weight, height);


            // assert
            //Assert.Throws(typeof(ArgumentException), () => calculator.CalculateBmi(weight, height));
            Assert.Throws<ArgumentException>(action);
            //Assert.Throws<ArgumentException>(() => calculator.CalculateBmi(weight, height));
        }
    }
}
