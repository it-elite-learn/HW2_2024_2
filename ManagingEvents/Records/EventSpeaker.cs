/// <summary>
/// Represents a speaker at an event, encompassing the speaker's name, biography, and topic.
/// </summary>
/// <param name="Name">The name of the event speaker.</param>
/// <param name="Bio">A short biography of the event speaker.</param>
/// <param name="Topic">The topic that the event speaker will discuss.</param>
public record EventSpeaker(string Name, string Bio, string Topic);
