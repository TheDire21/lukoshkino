namespace lukoshkino.Models
{
    public class Product_Photo
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int FileId { get; set; }

        public File? File { get; set; }
    }
}
