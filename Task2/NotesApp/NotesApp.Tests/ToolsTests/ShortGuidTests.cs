using System;
using NotesApp.Tools;
using Moq;
using Xunit;

namespace NotesApp.Tests
{
    public class ShortGuidTests
    {
        [Fact]
        public void ToShortId_Correctly_Transforms_Guid_To_ShortId()
        {
            var guid = new Guid();
            Assert.Equal(guid, guid.ToShortId().FromShortId());
        }

        [Fact]
        public void FromShortId_Correctly_Transforms_Guid_From_ShortId()
        {
            var guid = new Guid();
            Assert.Equal(guid, guid.ToString().FromShortId());
        }

        [Fact]
        public void FromShortId_Correctly_Handles_Adding_Two_Equals_Symbols_To_ShortId()
        {
            var guid = Guid.NewGuid();
            Assert.Equal(guid, (guid.ToShortId() + "==").FromShortId());
        }

        [Fact]
        public void FromShortId_Correctly_Transporms_String_Guid_To_Guid()
        {
            var guid = Guid.NewGuid();
            Assert.Equal(guid, guid.ToString().FromShortId());
        }

        [Fact]
        public void FromShortId_Throws_FormatException_If_Argument_Is_Invalid()
        {
            Assert.Throws<FormatException>(() => "invalid".FromShortId());
        }

        [Fact]
        public void FromShortId_Returns_Null_If_Value_Is_Null()
        {
            Assert.Null(ShortGuid.FromShortId(null));
        }
    }
}
