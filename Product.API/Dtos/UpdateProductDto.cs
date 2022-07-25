namespace Product.API.Dtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
    }
}
