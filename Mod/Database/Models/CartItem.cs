using Mod.Database.Models;

public class CartItem
{
    public TicketType Ticket { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal TotalPrice => (decimal)(Ticket.BasePrice * Quantity);
}