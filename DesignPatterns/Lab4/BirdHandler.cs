namespace Coding.SOLID
{
    internal class BirdHandler
    {
        private readonly BirdProducer _birdProducer;

        public BirdHandler() : this(new BirdProducer()) { }

        public BirdHandler(BirdProducer birdProducer)
        {
            _birdProducer = birdProducer ?? throw new ArgumentNullException(nameof(birdProducer));
        }

        public void DoBirdAction()
        {
            IBird sparrow = _birdProducer.ProduceBird("Sparrow");
            IBird pinguin = _birdProducer.ProduceBird("Pinguin");

            HandleBirdMoves(sparrow);
            HandleBirdMoves(pinguin);

            HandleBirdMultiplies(sparrow);
            HandleBirdMultiplies(pinguin);

            HandleBirdGrowsAChild(sparrow);
            HandleBirdGrowsAChild(pinguin);
        }

        private void HandleBirdMultiplies(IBird bird)
        {
            bird.SearchForSpause();
            bird.Sing();
            bird.Dance();
        }

        private void HandleBirdMoves(IBird bird)
        {
            bird.Walk();

            if (bird is IFlyingBird flyingBird)
                flyingBird.Fly();
        }

        private void HandleBirdGrowsAChild(IBird bird)
        {
            bird.ProduceEgg();
            bird.DefendEgg();
        }
    }
}
