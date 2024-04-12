namespace MatecProjectWebUI.Models
{
    public class ProcedureBestPriceModel
    {
        public string ProductCode { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DateTime ValidityDate { get; set; }
        public string Company { get; set; }
    }
}
