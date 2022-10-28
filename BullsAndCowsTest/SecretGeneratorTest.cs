using BullsAndCows;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_return_secret_with_4_characters_when_generate_secret()
        {
            //given
            var secretGenerator = new SecretGenerator();
            //when
            var secret = secretGenerator.GenerateSecret();
            //then
            Assert.Equal(4, secret.Split(" ").Length);
        }

        [Fact]
        public void Should_return_secret_with_4_random_characters_and_each_digits_is_different_when_generate_secret()
        {
            //given
            var mockRandom = new Mock<Random>();
            mockRandom.SetupSequence(random => random.Next(It.IsAny<int>())).Returns(1).Returns(1).Returns(5).Returns(4).Returns(5).Returns(3);
            var secretGenerator = new SecretGenerator(mockRandom.Object);
            //when
            var generateSecret = secretGenerator.GenerateSecret();
            //then
            Assert.Equal("1 5 4 3", generateSecret);
        }
    }
}
