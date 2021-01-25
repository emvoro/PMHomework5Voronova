using System;
using NotesApp.Tools;
using Moq;
using Xunit;

namespace NotesApp.Tests
{
    public class StringGeneratorTests
    {
        [Fact]
        public void GenerateNumbersString_Returns_Empty_String_If_Length_Is_Zero()
        {
            Assert.Equal(string.Empty, StringGenerator.GenerateNumbersString(0, true));
        }

        [Fact]
        public void GenerateNumbersString_Throws_ArgumentException_If_Argument_Is_Invalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringGenerator.GenerateNumbersString(-1, true));
        }

        [Fact]
        public void GenerateNumbersString_Generates_String_Without_Leading_Zero()
        {
            Assert.NotEqual('0', StringGenerator.GenerateNumbersString(8, false)[0]);
        }

        [Fact]
        public void GenerateNumbersString_Returns_String_With_Set_Length()
        {
            Assert.Equal(8, StringGenerator.GenerateNumbersString(8, false).Length);
        }

        [Fact]
        public void GenerateNumbersString_Returns_Number_With_Set_Length_Can_Be_Converted_To_Number_Type()
        {
            Assert.True(long.TryParse(StringGenerator.GenerateNumbersString(8, false), out _));
        }
    }
}
