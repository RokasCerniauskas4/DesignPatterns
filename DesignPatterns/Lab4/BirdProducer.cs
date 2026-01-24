using System;

namespace Coding.SOLID
{
    public class BirdProducer
    {
        public IBird ProduceBird(string birdType)
        {
            if (birdType == "Pinguin")
                return new Pinguin();

            if (birdType == "Sparrow")
                return new Sparrow();

            throw new ArgumentException($"Unknown bird type: {birdType}", nameof(birdType));
        }
    }
}
