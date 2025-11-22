namespace task1;

public interface IImage
{
    void Show();
}

public class RealImage : IImage
{
    private readonly string _fileName;

    public RealImage(string fileName)
    {
        _fileName = fileName;
        LoadFromDisk(_fileName);
    }

    private void LoadFromDisk(string fileName)
    {
        Console.WriteLine($"RealImage: loading image '{fileName}' from disk...");
    }

    public void Show()
    {
        Console.WriteLine($"RealImage: displaying image '{_fileName}'.");
    }
}

public class ImageProxy : IImage
{
    private readonly string _fileName;
    private RealImage? _realImage;

    public ImageProxy(string fileName)
    {
        _fileName = fileName;
    }

    public void Show()
    {
        if (_realImage == null)
        {
            _realImage = new RealImage(_fileName);
        }

        _realImage.Show();
    }
}

public static class ProxyDemo
{
    public static void Run()
    {
        IImage img = new ImageProxy("avatar.png");

        Console.WriteLine("== First time ==");
        img.Show();

        Console.WriteLine();
        Console.WriteLine("== Second time ==");
        img.Show();
    }
}