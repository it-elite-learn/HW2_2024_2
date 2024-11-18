/// <summary>
/// Represents an event with a title, date, location, list of speakers, and ticket price.
/// </summary>
/// <param name="Title">The title of the event.</param>
/// <param name="Date">The date and time when the event will take place.</param>
/// <param name="Location">The location where the event will be held, described by the EventLocation record.</param>
/// <param name="Speakers">A list of speakers participating in the event, each described by the EventSpeaker record.</param>
/// <param name="TicketPrice">The price of a ticket for the event.</param>
public record Event(
    string Title,
    DateTime Date,
    EventLocation Location,
    List<EventSpeaker> Speakers,
    decimal TicketPrice
);
