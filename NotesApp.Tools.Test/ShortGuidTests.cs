using System;
using Xunit;

namespace NotesApp.Tools.Test
{
    public class ShortGuidTests
    {
        [Fact]
        public void Should_Convert_Guid_Correctly()
        {
            var id = Guid.NewGuid();
            var shortId = ShortGuid.ToShortId(id);
            var longId = ShortGuid.FromShortId(shortId);
            Assert.Equal(id, longId);
        }

        [Fact]
        public void FromShortId_Should_Convert_Correctly()
        {
            var shortId = Guid.NewGuid().ToShortId() + "==";
            Assert.NotNull(ShortGuid.FromShortId(shortId));

            shortId = ShortGuid.ToShortId(Guid.NewGuid()) + "==";
            Assert.NotNull(ShortGuid.FromShortId(shortId));
        }

        [Fact]
        public void FromShortId_Should_Convert_String_Correctly()
        {
            var guid = Guid.NewGuid().ToString();
            var expectedGuid = guid.FromShortId();
            Assert.Equal(expectedGuid, ShortGuid.FromShortId(guid));
        }

        [Fact]
        public void FromShortId_Should_Fail_If_Argument_Invalid()
        {
            Assert.Throws<FormatException>(() => ShortGuid.FromShortId("1234"));
        }

        [Fact]
        public void FromShortId_Returns_Null_If_Argument_Null()
        {
            Assert.Null(ShortGuid.FromShortId(null));
        }
    }
}
