namespace MicroservicesWithCQRSDesignPattern.Queries.QueryModel
{
    public class GetAllProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}
