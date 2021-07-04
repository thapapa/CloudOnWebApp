
namespace CloudOnWebApp.Options
{
    public class CreateProductOptions
    {
        public int ExternalId { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Barcode { get; set; }
        public double RetailPrice { get; set; }
        public double WholePrice { get; set; }
        public double Discount { get; set; }
    }
}
