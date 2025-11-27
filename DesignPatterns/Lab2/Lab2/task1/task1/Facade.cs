namespace task1;


public class TimerService
{
    public void StartPomodoro(int minutes)
    {
        Console.WriteLine($"TimerService: starting Pomodoro for {minutes} minutes.");
    }

    public void StartBreak(int minutes)
    {
        Console.WriteLine($"TimerService: starting break for {minutes} minutes.");
    }

    public void Stop()
    {
        Console.WriteLine("TimerService: stopping timer.");
    }
}

public class NotesService
{
    public void OpenNotes(string subject)
    {
        Console.WriteLine($"NotesService: opening notes for '{subject}'.");
    }

    public void SaveNotes()
    {
        Console.WriteLine("NotesService: saving current notes.");
    }

    public void CloseNotes()
    {
        Console.WriteLine("NotesService: closing notes.");
    }
}

public class FocusService
{
    public void EnableFocusMode()
    {
        Console.WriteLine("FocusService: enabling focus mode " +
                          "(mute notifications, close socials).");
    }

    public void DisableFocusMode()
    {
        Console.WriteLine("FocusService: disabling focus" +
                          " mode (notifications back on).");
    }
}

public class MusicService
{
    public void PlayFocusPlaylist()
    {
        Console.WriteLine("MusicService: playing focus playlist.");
    }

    public void StopMusic()
    {
        Console.WriteLine("MusicService: stopping music.");
    }
}


public class StudySessionFacade
{
    private readonly TimerService _timer;
    private readonly NotesService _notes;
    private readonly FocusService _focus;
    private readonly MusicService _music;

    public StudySessionFacade(
        TimerService timer,
        NotesService notes,
        FocusService focus,
        MusicService music)
    {
        _timer = timer;
        _notes = notes;
        _focus = focus;
        _music = music;
    }
    
    public void StartStudySession(string subject, int minutes)
    {
        Console.WriteLine("=== StartStudySession() via StudySessionFacade ===");

        _focus.EnableFocusMode();
        _notes.OpenNotes(subject);
        _music.PlayFocusPlaylist();
        _timer.StartPomodoro(minutes);
    }
    
    public void TakeBreak(int minutes)
    {
        Console.WriteLine("=== TakeBreak() via StudySessionFacade ===");

        _timer.StartBreak(minutes);
        _music.StopMusic();
        Console.WriteLine("You can stretch, drink water, check phone (just a bit 😏).");
    }
    
    public void EndStudySession()
    {
        Console.WriteLine("=== EndStudySession() via StudySessionFacade ===");

        _timer.Stop();
        _music.StopMusic();
        _notes.SaveNotes();
        _notes.CloseNotes();
        _focus.DisableFocusMode();
    }
}

public static class FacadeDemo
{
    public static void Run()
    {
        var timer = new TimerService();
        var notes = new NotesService();
        var focus = new FocusService();
        var music = new MusicService();

        var study = new StudySessionFacade(timer, notes, focus, music);

        study.StartStudySession("Design Patterns", 25);
        Console.WriteLine();

        study.TakeBreak(5);
        Console.WriteLine();

        study.EndStudySession();
        Console.WriteLine();
    }
}
