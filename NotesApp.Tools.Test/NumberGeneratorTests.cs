using System;
using Xunit;

namespace NotesApp.Tools.Test
{
    public class NumberGeneratorTests
    {
        [Fact]
        public void GeneratePositiveLong_Should_Fail_If_Argument_Invalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberGenerator.GeneratePositiveLong(-4));
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberGenerator.GeneratePositiveLong(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberGenerator.GeneratePositiveLong(19));
        }

        [Fact]
        public void GeneratePositiveLong_Should_Retur_Valid_Length()
        {
            var expectedLength = NumberGenerator.GeneratePositiveLong(3).ToString().Length;
            var length = NumberGenerator.GeneratePositiveLong(3).ToString().Length;

            Assert.Equal(expectedLength, length);
            Assert.Equal(3, length);
            for (int i = 1; i < 19; i++)
            {
                //Assert.Equal(i, NumberGenerator.GeneratePositiveLong(i).ToString().Length);
                Assert.True(NumberGenerator.GeneratePositiveLong(i).ToString().Length == i);
            }
        }
    }
}
