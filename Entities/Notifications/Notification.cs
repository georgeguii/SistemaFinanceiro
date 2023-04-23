using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notifications;

public class Notification
{

    public Notification()
    {
        _notifications = new List<Notification>();
    }

    [NotMapped]
    public string NameProperty { get; set; }

    [NotMapped]
    public string Message { get; set; }

    [NotMapped]
    private readonly List<Notification> _notifications;

    private void AddNotification(string message, string propertyName)
    {
        _notifications.Add(new Notification
        {
            Message = message,
            NameProperty = propertyName,
        });
    }

    public bool ValidateStringProperty(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
        {
            AddNotification("Required field", propertyName);
            return false;
        }

        return true;
    }

    public bool ValidateIntProperty(int value, string propertyName)
    {
        if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
        {
            AddNotification("Required field", propertyName);
            return false;
        }

        return true;
    }
}
