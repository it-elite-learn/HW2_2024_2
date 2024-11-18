var manager = new EventManager();
manager.Setup();

manager.OnEventAdded += (evt, message) => 
    Console.WriteLine($"New event added: {evt.Title} - {message}");

var location = new EventLocation("Tech Hub", "123 Main St", 100);
var speaker = new EventSpeaker("John Doe", "Tech Expert", "C# Modern Features");
var newEvent = new Event(
    "C# Workshop",
    DateTime.Now.AddDays(30),
    location,
    new List<EventSpeaker> { speaker },
    199.99m
);

manager.AddEvent(newEvent);
Console.WriteLine(newEvent.Location.Capacity);
manager.BuyTickets(newEvent,10);
Console.WriteLine(newEvent.Location.Capacity);

Console.WriteLine(newEvent.ToDetailedString());
Console.WriteLine($"Is sold out: {newEvent.IsSoldOut()}");