using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        private Random random;

        public SecretGenerator()
        {

        }

        public SecretGenerator(Random random)
        {
            this.random = random;
        }

        public virtual string GenerateSecret()
        {
            var digits = new List<int>();
            for (var index = 0; index < 4;)
            {
                var digit = random.Next(10);
                if (!digits.Contains(digit))
                {
                    digits.Add(digit);
                    index++;
                }
            }

            return string.Join(" ", digits);
        }
    }
}