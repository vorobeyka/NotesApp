using System;
using Xunit;

namespace NotesApp.Tools.Test
{
    public class StringGeneratorTests
    {
        [Fact]
        public void GenerateNumbersString_Should_Return_Empty_String()
        {
            var generatedString = StringGenerator.GenerateNumbersString(0, false);

            Assert.Empty(generatedString);
            generatedString = StringGenerator.GenerateNumbersString(0, true);
            Assert.Empty(generatedString);
        }

        [Fact]
        public void GenerateNumbersString_Should_Fail_If_Value_Invalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringGenerator.GenerateNumbersString(-1, true));
            Assert.Throws<ArgumentOutOfRangeException>(() => StringGenerator.GenerateNumbersString(-100, false));
        }

        [Fact]
        public void GenerateNumbersString_Should_Return_String_Not_Lead_By_Zero()
        {
            var expectedCharacter = StringGenerator.GenerateNumbersString(1, false)[0];

            Assert.InRange(expectedCharacter, '1', '9');
            for (int i = 1; i <= 18; i++)
            {
                //Assert.InRange(StringGenerator.GenerateNumbersString(i, false)[0], '1', '9');
                Assert.True(StringGenerator.GenerateNumbersString(i, false)[0] != '0');
            }
        }

        [Fact]
        public void GenerateNumbersString_Should_Return_Valid_Length()
        {
            for (int i = 0; i < 19; i++)
            {
                //Assert.Equal(i, StringGenerator.GenerateNumbersString(i, true).Length);
                Assert.True(StringGenerator.GenerateNumbersString(i, true).Length == i);
            }
        }

        [Fact]
        public void GenerateNumbersString_Should_Convert_To_Long()
        {
            for (int i = 1; i < 19; i++)
            {
                Assert.IsType<long>(long.Parse(StringGenerator.GenerateNumbersString(i, true)));
            }
        }
    }
}
