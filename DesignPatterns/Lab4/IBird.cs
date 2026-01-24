namespace Coding.SOLID
{
    public interface IBird
    {
        void Sing();
        void Dance();
        void Walk();
        void ProduceEgg();
        void DefendEgg();
        void SearchForSpause();
    }

    public interface IFlyingBird : IBird
    {
        void Fly();
    }
}
