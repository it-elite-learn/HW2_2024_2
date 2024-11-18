namespace System;

/// <summary>
/// Provides extension methods for the <see cref="Event"/> class.
/// </summary>
public static class EventExtensions
{
    /// <summary>
    /// Determines whether the given event is sold out based on its location capacity.
    /// </summary>
    /// <param name="evt">The event to check for sold-out status.</param>
    /// <returns>True if the event is sold out, otherwise false.</returns>
    public static bool IsSoldOut(this Event evt) => evt.Location.Capacity == 0;

    /// <summary>
    /// Calculates the duration of the event in hours from the event's start time to the specified end time.
    /// </summary>
    /// <param name="evt">The event for which to calculate the duration.</param>
    /// <param name="endTime">The end time to calculate the duration up to.</param>
    /// <returns>The duration of the event in hours.</returns>
    public static double GetDurationInHours(this Event evt, DateTime endTime) => (endTime - evt.Date).TotalHours;

    /// <summary>
    /// Returns a detailed string representation of the event.
    /// </summary>
    /// <param name="evt">The event to create a detailed string for.</param>
    /// <returns>A string containing detailed information about the event including title, date, venue, speakers, and ticket price.</returns>
    public static string ToDetailedString(this Event evt)
        => $@"Event: {evt.Title}, 
               Date: {evt.Date}, 
               Venue: {evt.Location.venue}, 
               Speakers: {string.Join(", ", evt.Speakers.Select(s => s.Name))}, 
               Price: ${evt.TicketPrice:F2}";

    /// <summary>
    /// Configures the event manager by adding validation rules and a price calculator.
    /// </summary>
    /// <param name="manager">The event manager to configure.</param>
    /// <returns>The configured event manager.</returns>
    public static EventManager Setup(this EventManager manager)
    {
        manager.AddValidationRule(evt => evt.Date > DateTime.Now);
        manager.AddValidationRule(evt => evt.TicketPrice > 0);
        manager.AddValidationRule(evt => evt.Speakers.Count > 0);

        manager.SetPriceCalculator((evt, quantity) =>
        {
            var basePrice = evt.TicketPrice * quantity;
            var bulkDiscount = quantity >= 5 ? 0.9m : 1.0m;
            var speakerPremium = evt.Speakers.Count > 3 ? 1.2m : 1.0m;
            return basePrice * bulkDiscount * speakerPremium;
        });

        return manager;
    }
}