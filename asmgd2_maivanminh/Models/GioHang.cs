namespace asmgd2_maivanminh.Models
{
    public class GioHang
    {
        public string Descriptions { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Soluong { get; set; }
        public decimal? ThanhTien => Soluong * Price;

    }
}
