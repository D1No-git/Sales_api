namespace sales_api.Models.Reports
{
    public class SalesReport
    {
        public DateTime Date { get; set; }
        public int TotalArticlesSold { get; set; }
        public int TotalUniqueArticlesSold { get; set; }
    }
}
