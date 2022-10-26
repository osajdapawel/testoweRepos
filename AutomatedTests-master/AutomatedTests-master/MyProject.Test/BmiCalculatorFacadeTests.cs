using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Test
{
    public class BmiCalculatorFacadeTests
    {
        private const string EXPECTED_SUMMARY = "Your extreme obesity might cause health problems";

        [Fact]
        public void GetResult_ForValidInput_ReturnsCorrectResult()
        {
            // arrange
            BmiCalculatorFacade bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, );
            double weight = 90;
            double height = 100;

            // act
            var result = bmiCalculatorFacade.GetResult(weight, height);

            // assert
            Assert.Equal(24.93, result.Bmi);
            Assert.Equal(BmiClassification.ExtremeObesity, result.BmiClassification);
            Assert.Equal(EXPECTED_SUMMARY, result.Summary);
        }
    }
}
