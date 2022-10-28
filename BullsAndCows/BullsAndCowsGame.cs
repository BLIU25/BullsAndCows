using System;

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

            return $"{countBulls}A0B";
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