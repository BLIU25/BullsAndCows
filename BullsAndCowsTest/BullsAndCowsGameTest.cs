using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4A0B_when_guess_given_the_guess_digits_are_same_as_secret()
        {
            //given
            var mockGenerator = new Mock<SecretGenerator>();
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns("1 2 3 4");
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            var guessResult = game.Guess("1 2 3 4");
            //then
            Assert.Equal("4A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 2 5 6")]
        [InlineData("1 2 3 4", "5 2 3 6")]
        [InlineData("1 2 3 4", "1 7 3 6")]
        public void Should_return_2A0B_when_guess_given_the_guess_having_2_digits_with_value_and_position_are_same_as_secret(string secret, string guessDigits)
        {
            //given
            var mockGenerator = new Mock<SecretGenerator>();
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            var guessResult = game.Guess(guessDigits);
            //then
            Assert.Equal("2A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 3 5 6")]
        [InlineData("1 2 3 4", "2 5 3 6")]
        [InlineData("1 2 3 4", "3 7 8 4")]
        public void Should_return_1A1B_when_guess_given_the_guess_having_1_digit_with_value_and_position_and_1_digit_only_value_are_same_as_secret(string secret, string guessDigits)
        {
            //given
            var mockGenerator = new Mock<SecretGenerator>();
            mockGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockGenerator.Object);
            //when
            var guessResult = game.Guess(guessDigits);
            //then
            Assert.Equal("1A1B", guessResult);
        }
    }
}
