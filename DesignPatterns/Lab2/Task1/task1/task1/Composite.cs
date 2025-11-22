namespace task1;

public interface IFileSystemItem
{
    void Delete();
}

public class FileItem : IFileSystemItem
{
    private readonly string _name;

    public FileItem(string name)
    {
        _name = name;
    }

    public void Delete()
    {
        Console.WriteLine($"Deleting FILE: {_name}");
    }
}

public class Folder : IFileSystemItem
{
    private readonly string _name;
    private readonly List<IFileSystemItem> _children = new();

    public Folder(string name)
    {
        _name = name;
    }

    public void Add(IFileSystemItem item)
    {
        _children.Add(item);
    }

    public void Remove(IFileSystemItem item)
    {
        _children.Remove(item);
    }

    public void Delete()
    {
        Console.WriteLine($"Deleting FOLDER: {_name}");

        foreach (var child in _children)
        {
            child.Delete();
        }
    }
}

public static class CompositeDemo
{
    public static void Run()
    {
        var root = new Folder("Root");
        
        root.Add(new FileItem("file1.txt"));
        root.Add(new FileItem("file2.txt"));
        
        var documents = new Folder("Documents");
        documents.Add(new FileItem("cv.docx"));
        documents.Add(new FileItem("report.pdf"));
        
        var images = new Folder("Images");
        images.Add(new FileItem("photo1.png"));
        images.Add(new FileItem("photo2.jpg"));
        
        root.Add(documents);
        root.Add(images);

        root.Delete();
    }
}
