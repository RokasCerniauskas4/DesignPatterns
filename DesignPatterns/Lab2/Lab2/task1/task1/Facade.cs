namespace task1;

public class TimerService
{
    public void StartPomodoro(int minutes)
        => Console.WriteLine($"Timer: Pomodoro {minutes} min.");

    public void StartBreak(int minutes)
        => Console.WriteLine($"Timer: break {minutes} min.");

    public void Stop()
        => Console.WriteLine("Timer: stop.");
}

public class NotesService
{
    public void OpenNotes(string subject)
        => Console.WriteLine($"Notes: open '{subject}'.");

    public void SaveNotes()
        => Console.WriteLine("Notes: save.");

    public void CloseNotes()
        => Console.WriteLine("Notes: close.");
}

public class FocusService
{
    public void EnableFocusMode()
        => Console.WriteLine("Focus: ON.");

    public void DisableFocusMode()
        => Console.WriteLine("Focus: OFF.");
}

public class MusicService
{
    public void PlayFocusPlaylist()
        => Console.WriteLine("Music: play focus playlist.");

    public void StopMusic()
        => Console.WriteLine("Music: stop.");
}

public class StudySessionFacade
{
    private readonly TimerService _timer = new();
    private readonly NotesService _notes = new();
    private readonly FocusService _focus = new();
    private readonly MusicService _music = new();
    
    public void Run(string subject, int focusMinutes = 25, int breakMinutes = 5)
    {
        Console.WriteLine("=== STUDY SESSION ===");
        
        _focus.EnableFocusMode();
        _notes.OpenNotes(subject);
        _music.PlayFocusPlaylist();
        _timer.StartPomodoro(focusMinutes);
        
        _timer.StartBreak(breakMinutes);
        _music.StopMusic();
        Console.WriteLine("Break: you can relax now and drink couple of litres beer");
        
        _timer.Stop();
        _notes.SaveNotes();
        _notes.CloseNotes();
        _focus.DisableFocusMode();
    }
}

public static class FacadeDemo
{
    public static void Run()
    {
        var study = new StudySessionFacade();
        
        study.Run("Design Patterns");
    }
}
