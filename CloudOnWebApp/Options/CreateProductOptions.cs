
namespace CloudOnWebApp.Options
{
    public class CreateProductOptions
    {
        public long ExternalId { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public long Barcode { get; set; }
        public double RetailPrice { get; set; }
        public double WholePrice { get; set; }
        public double Discount { get; set; }
    }
}
