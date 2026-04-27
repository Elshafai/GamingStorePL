namespace GamingStorePL.ViewModels
{
    public class GameVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Cover { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public IEnumerable<string> Devices { get; set; } = Enumerable.Empty<string>();
    }
}
