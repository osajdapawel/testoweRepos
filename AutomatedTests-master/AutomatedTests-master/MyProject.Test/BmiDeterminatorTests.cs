using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Test
{
    public class BmiDeterminatorTests
    {
        //[Fact] - jeden test jednostkowy
        //[Fact] //- jeden test jednostkowy
        //public void DetermineBmi_BmiBelow18_5_ReturnsUnderweight()


        [Theory] // - kilka 
        [InlineData(10.0, BmiClassification.Underweight)]
        [InlineData(12.0, BmiClassification.Underweight)]
        [InlineData(20, BmiClassification.Normal)]
        [InlineData(27.5, BmiClassification.Overweight)]
        public void DetermineBmi_ForParticularBMI_ReturnsCorrectClassification(double bmi, BmiClassification expected)
        {
            // arrange
            BmiDeterminator bmiDeterminator = new BmiDeterminator();

            // act
            BmiClassification result = bmiDeterminator.DetermineBmi(bmi);


            // assert
            Assert.Equal(expected, result);


        }
    }
}
