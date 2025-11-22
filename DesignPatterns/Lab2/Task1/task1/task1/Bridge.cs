namespace task1;

public interface INotificationSender
{
    void Send(string title, string message);
}

public class EmailNotificationSender : INotificationSender
{
    public void Send(string title, string message)
    {
        Console.WriteLine($"EMAIL {title}: {message}");
    }
}

public class SmsNotificationSender : INotificationSender
{
    public void Send(string title, string message)
    {
        Console.WriteLine($"SMS {title}: {message}");
    }
}

public abstract class Notification
{
    protected readonly INotificationSender sender;

    protected Notification(INotificationSender sender)
    {
        this.sender = sender;
    }

    public abstract void Notify(string message);
}

public class AlertNotification : Notification
{
    public AlertNotification(INotificationSender sender) : base(sender)
    {
    }

    public override void Notify(string message)
    {
        sender.Send("ALERT", message);
    }
}

public class ReminderNotification : Notification
{
    public ReminderNotification(INotificationSender sender) : base(sender)
    {
    }

    public override void Notify(string message)
    {
        sender.Send("REMINDER", message);
    }
}

public static class BridgeDemo
{
    public static void Run()
    {
        INotificationSender emailSender = new EmailNotificationSender();
        Notification emailAlert = new AlertNotification(emailSender);
        emailAlert.Notify("Server is down!");

        INotificationSender smsSender = new SmsNotificationSender();
        Notification smsAlert = new AlertNotification(smsSender);
        smsAlert.Notify("Battery low!");

        Notification smsReminder = new ReminderNotification(smsSender);
        smsReminder.Notify("Meeting at 15:00");
    }
}
