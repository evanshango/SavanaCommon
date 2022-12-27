namespace Treasures.Common.Helpers;

public record UserEvent(string UserId, string Json, string EventType);

public record ProductEvent(string ProductId, string Json, string EventType);

public record OrderEvent(string OrderId, string Json, string EventType);

public record NotificationEvent(string Json, string EventType);

public record BasketEvent(string BuyerId);

public record PaymentEvent(string OrderId, string Json);