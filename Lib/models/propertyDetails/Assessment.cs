#nullable enable
namespace Lib.models.propertyDetails{
    public class Assessment {
        public string? apn {get; set;}
        public int? assessment_year {get; set;}
        public int? tax_amount {get; set;}
        public int? tax_year {get; set;}
        public decimal? total_assessed_value {get; set;}
    }
}