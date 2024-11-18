using System.ComponentModel.DataAnnotations;

/// <summary>
/// Manages events by allowing addition, validation, and ticket purchases.
/// Supports notification when a new event is added.
/// </summary>
public class EventManager
{
    /// <summary>
    /// A private list of events managed by the <see cref="EventManager"/> class.
    /// Used for storing and retrieving event details.
    /// </summary>
    private List<Event> _events = new();

    /// <summary>
    /// Event raised when a new event is added in the <see cref="EventManager"/> class.
    /// Subscribers can use this to get notified about new events.
    /// </summary>
    public event EventNotification OnEventAdded;

    /// <summary>
    /// A private list of event validation rules used by the <see cref="EventManager"/> class.
    /// Ensures that newly added events meet the necessary criteria before being accepted.
    /// </summary>
    private List<EventValidator> _validationRules = new();

    /// <summary>
    /// A private delegate of type <see cref="PriceCalculator"/> used by the <see cref="EventManager"/> class.
    /// Responsible for calculating the total price of tickets based on the event and quantity.
    /// </summary>
    private PriceCalculator _priceCalculator;

    /// <summary>
    /// Adds a new event to the event manager after validating it against all
    /// registered validation rules. If the event is valid, it triggers the
    /// <see cref="OnEventAdded"/> event.
    /// </summary>
    /// <param name="evt">The event to be added.</param>
    /// <exception cref="ValidationException">Thrown when the event does not pass one or more validation rules.</exception>
    public void AddEvent(Event evt)
    {
        if (_validationRules.Any(rule => !rule(evt)))
            throw new ValidationException("Invalid event");

        TriggerOnEventAdded(evt,$@"Successfully added event ""{evt.Title}"" ");
    }

    /// <summary>
    /// Adds a new validation rule to the event manager. This rule will be used to
    /// validate events before they are added to the manager.
    /// </summary>
    /// <param name="validator">The validation rule to be added, represented as a delegate function.</param>
    public void AddValidationRule(EventValidator validator) =>
        _validationRules.Add(validator);

    /// <summary>
    /// Sets the price calculator for the event manager, which is used to calculate
    /// the total price of tickets based on the event and quantity.
    /// </summary>
    /// <param name="calculator">A delegate of type <see cref="PriceCalculator"/> that defines the pricing logic.</param>
    public void SetPriceCalculator(PriceCalculator calculator)
    {
        _priceCalculator = calculator;
    }

    /// <summary>
    /// Retrieves the list of events currently managed by the EventManager.
    /// </summary>
    /// <returns>An IEnumerable of Event objects representing the managed events.</returns>
    public IEnumerable<Event> GetEvents()
    {
        return _events;
    }

    /// <summary>
    /// Purchases a specified quantity of tickets for a given event, decreases the event's capacity, and calculates the total price.
    /// </summary>
    /// <param name="evt">The event for which tickets are being purchased.</param>
    /// <param name="quantity">The number of tickets to purchase.</param>
    /// <returns>The total price of the purchased tickets.</returns>
    /// <exception cref="InvalidOperationException">Thrown when there are not enough tickets available.</exception>
    public decimal BuyTickets(Event evt, int quantity)
    {
        if (evt.Location.Capacity - quantity < 0)
        {
            throw new InvalidOperationException("Not enough tickets available");
        }

        evt.Location.Capacity -= quantity;
        return _priceCalculator(evt, quantity);
    }

    /// <summary>
    /// Triggers the <see cref="OnEventAdded"/> event to notify subscribers that a new event has been added to the event manager.
    /// </summary>
    /// <param name="evt">The event that was added.</param>
    /// <param name="message">A message providing additional context about the added event.</param>
    protected virtual void TriggerOnEventAdded(Event evt, string message)
    {
        OnEventAdded?.Invoke(evt, message);
    }
}