# Event Planning System Exercise

## Overview
Create a simple event planning system that demonstrates the use of modern C# features including records, delegates, anonymous functions, and extension methods.

## Requirements

### 1. Data Models
Create the following records to represent event data:

```csharp
public record EventLocation(string Venue, string Address, int Capacity);

public record EventSpeaker(string Name, string Bio, string Topic);

public record Event(
    string Title,
    DateTime Date,
    EventLocation Location,
    List<EventSpeaker> Speakers,
    decimal TicketPrice
);
```

### 2. Delegate Definitions
Define the following delegates for event management:

```csharp
// Delegate for validating events
public delegate bool EventValidator(Event evt);

// Delegate for price calculations
public delegate decimal PriceCalculator(Event evt, int quantity);

// Delegate for event notifications
public delegate void EventNotification(Event evt, string message);
```

### 3. Core Implementation
Create an `EventManager` class with the following features:

```csharp
public class EventManager
{
    private List<Event> _events = new();
    
    // Event notification handler
    public event EventNotification OnEventAdded;
    
    // Validation rules storage
    private List<EventValidator> _validationRules = new();
    
    // Price calculator storage
    private PriceCalculator _priceCalculator;

    public void AddEvent(Event evt)
    {
        // Implementation required
    }

    public void AddValidationRule(EventValidator validator)
    {
        // Implementation required
    }

    public void SetPriceCalculator(PriceCalculator calculator)
    {
        // Implementation required
    }

    public List<Event> GetEvents()
    {
        // Implementation required
        return null;
    }
}
```

### 4. Extension Methods
Create an `EventExtensions` class with the following extension methods:

```csharp
public static class EventExtensions
{
    // Add an extension method to check if an event is sold out
    public static bool IsSoldOut(this Event evt)
    {
        // Implementation required
        return false;
    }

    // Add an extension method to get the event duration in hours
    public static double GetDurationInHours(this Event evt, DateTime endTime)
    {
        // Implementation required
        return 0;
    }

    // Add an extension method to format event details as a string
    public static string ToDetailedString(this Event evt)
    {
        // Implementation required
        return string.Empty;
    }
}
```

## Tasks

1. Complete the `EventManager` class implementation:
   - Implement the `AddEvent` method to validate the event using all registered validation rules before adding it
   - Trigger the `OnEventAdded` event when a new event is successfully added
   - Use the price calculator when calculating total prices

2. Create validation rules using anonymous functions:
   - Create a rule that ensures the event date is in the future
   - Create a rule that ensures the ticket price is positive
   - Create a rule that validates speaker count (minimum 1 speaker)

3. Implement a price calculator using anonymous functions:
   - Calculate bulk discounts (e.g., 10% off for 5+ tickets)
   - Add premium pricing for events with more than 3 speakers

4. Complete the extension methods implementation:
   - `IsSoldOut`: Check if the event location capacity is reached
   - `GetDurationInHours`: Calculate duration between event start and end time
   - `ToDetailedString`: Format event details including location and speakers

## Example Usage

```csharp
// Example of how the completed implementation should work
var manager = new EventManager();

// Add validation rules using anonymous functions
manager.AddValidationRule(evt => evt.Date > DateTime.Now);
manager.AddValidationRule(evt => evt.TicketPrice > 0);

// Set price calculator using anonymous function
manager.SetPriceCalculator((evt, quantity) => {
    var basePrice = evt.TicketPrice * quantity;
    return quantity >= 5 ? basePrice * 0.9m : basePrice;
});

// Subscribe to event notifications using anonymous function
manager.OnEventAdded += (evt, message) => 
    Console.WriteLine($"New event added: {evt.Title} - {message}");

// Create and add an event
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

// Use extension methods
Console.WriteLine(newEvent.ToDetailedString());
Console.WriteLine($"Is sold out: {newEvent.IsSoldOut()}");
```

## Evaluation Criteria

1. Correct implementation of all required features
2. Proper use of records for immutable data models
3. Effective use of delegates and events for loose coupling
4. Appropriate use of anonymous functions for validation and calculations
5. Clean and maintainable extension method implementations
6. Proper error handling and edge cases
7. Code organization and readability
8. Documentation (XML-Docs => summary)

## Bonus Challenges

1. Add support for canceling events
2. Implement speaker rating system
3. Add event search functionality using delegates
4. Create a waiting list system for sold-out events
5. Add support for recurring events
