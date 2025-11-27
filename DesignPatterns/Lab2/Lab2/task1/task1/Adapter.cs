namespace task1;

public interface IPlayer
{
    void Play();
}

public class OutdatedPlayer
{
    public void PlayFile()
    {
        Console.WriteLine("Playing file with outdated player...");
    }
}

public class OutdatedPlayerAdapter(OutdatedPlayer outdatedPlayer) : IPlayer
{
    public void Play()
    {
        outdatedPlayer.PlayFile();
    }
}

public static class AdapterDemo
{
    public static void Run()
    {
        var outdatedPlayer = new OutdatedPlayer();

        IPlayer player = new OutdatedPlayerAdapter(outdatedPlayer);

        player.Play();
    }
}
