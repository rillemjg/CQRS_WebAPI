namespace Commands.Commands
{
    public class AddQuantityCommand : ICommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
