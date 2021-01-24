using System;
using Xunit;

namespace NotesApp.Tools.Test
{
    public class ShortGuidTests
    {
        [Fact]
        public void Should_Convert_Guid_Correctly()
        {
            var guid = Guid.NewGuid();
            var shortGuid = ShortGuid.ToShortId(guid);
            var longGuid = ShortGuid.FromShortId(shortGuid);
            Assert.Equal(guid, longGuid);
        }

        [Fact]
        public void FromShortId_Should_Convert_Correctly()
        {
            var shortGuid = ShortGuid.ToShortId(Guid.NewGuid());

        }
    }
}
