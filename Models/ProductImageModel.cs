namespace BaiTapNhom02_Lan_02.Models
{
    public class ProductImages
    {
        public int ImageId { get; set; }
        public int ProductId { get; set;} // FK to Products
        public string? ImageUrl { get; set; }
        public int SortOrder {  get; set; }

    }
}
