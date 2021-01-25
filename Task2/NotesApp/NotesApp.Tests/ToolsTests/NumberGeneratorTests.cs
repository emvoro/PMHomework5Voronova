using System;
using NotesApp.Tools;
using Moq;
using Xunit;

namespace NotesApp.Tests
{
    public class NumberGeneratorTests
    {
        [Fact]
        public void GeneratePositiveLong_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NumberGenerator.GeneratePositiveLong(0));
        }

        [Fact]
        public void GeneratePositiveLong_Returns_Number_With_Set_Number_Of_Symbols()
        {
            var numberLength = NumberGenerator.GeneratePositiveLong(8).ToString().Length;
            Assert.Equal(8, numberLength);
        }
    }
}
