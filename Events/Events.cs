namespace Treasures.Common.Events;

public record UserEvent(string UserId, string Json, string EventType);

public record ProductEvent(string ProductId, string Json, string EventType);

public record StockEvent(string ProductId, int Stock);

public record PromoEvent(string ProductId, double FinalPrice);

public record OrderEvent(string OrderId, string Json, string EventType);

public record NotificationEvent(string Json, string EventType);

public record BasketEvent(string BuyerId);

public record PaymentEvent(string OrderId, string Json);