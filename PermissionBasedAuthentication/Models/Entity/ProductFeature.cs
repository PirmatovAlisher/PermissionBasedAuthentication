namespace PermissionBasedAuthentication.Models.Entity
{
    public class ProductFeature
    {
        public int Id { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
