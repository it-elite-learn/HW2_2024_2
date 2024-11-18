/// <summary>
/// Represents the location of an event.
/// </summary>
/// <param name="venue">The name of the venue where the event is held.</param>
/// <param name="address">The address of the venue.</param>
/// <param name="Capacity">The maximum number of people that the venue can accommodate.</param>
public record EventLocation(string venue, string address)
{
    /// <summary>
    /// Represents the location of an event.
    /// </summary>
    /// <param name="venue">The name of the venue where the event is held.</param>
    /// <param name="address">The address of the venue.</param>
    /// <param name="capacity">The maximum number of people that the venue can accommodate.</param>
    public EventLocation(string venue, string address, int capacity) : this(venue, address)
    {
        Capacity = capacity;
    }

    /// <summary>
    /// Gets or sets the maximum number of people that the venue can accommodate.
    /// </summary>
    public int Capacity { get; set; }
}