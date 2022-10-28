using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var countBulls = CountBulls(guess);

            var countCows = CountCows(guess, countBulls);

            return $"{countBulls}A{countCows}B";
        }

        private int CountCows(string guess, int countBulls)
        {
            var guessDigits = guess.Split(separator: " ");
            var secretDigits = secret.Split(separator: " ");
            int countCows = 0;
            foreach (var secretDigit in secretDigits)
            {
                if (guessDigits.Contains(secretDigit))
                {
                    countCows++;
                }
            }

            countCows -= countBulls;
            return countCows;
        }

        private int CountBulls(string guess)
        {
            var guessDigits = guess.Split(separator: " ");
            var secretDigits = secret.Split(separator: " ");
            int countBulls = 0;
            for (var index = 0; index < 4; index++)
            {
                if (guessDigits[index] == secretDigits[index])
                {
                    countBulls++;
                }
            }

            return countBulls;
        }
    }
}