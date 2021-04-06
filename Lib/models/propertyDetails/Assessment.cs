#nullable enable
namespace Lib.Models.HouseCanary
{
    public class Assessment
    {
        public string? Apn { get; set; }
        public int? Assessment_year { get; set; }
        public decimal? Tax_amount { get; set; }
        public int? Tax_year { get; set; }
        public decimal? Total_assessed_value { get; set; }

        public void RoundDollarValues()
        {
            Tax_amount = Tax_amount.HasValue ? decimal.Round(Tax_amount.Value, 2) : null;
            Total_assessed_value = Total_assessed_value.HasValue ? decimal.Round(Total_assessed_value.Value, 2) : null;
        }
    }
}