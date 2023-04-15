using Entities.Notifications;

namespace Entities.Entitites;

public class Base : Notification
{
    public int Id { get; set; }

    public string Name { get; set; }
}
