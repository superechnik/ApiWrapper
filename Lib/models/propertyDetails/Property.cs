#nullable enable
namespace Lib.Models.HouseCanary {
    public class Property {
        public string? Air_conditioning {get; set;}
        public bool Attic {get ;set;}
        public string? Basement {get; set;}
        public int? Building_area_sq_ft {get; set;}
        public int? Building_condition_score {get; set;}
        public int? Building_quality_score {get; set;}
        public string? Construction_type {get; set;}
        public string? Exterior_walls {get; set;}
        public bool Fireplace {get; set;}
        public int? Full_bath_count {get ;set;}
        public int? Garage_parking_of_cars {get; set;}
        public string? Garage_type_parking {get ;set;}
        public string? Heating {get ;set;}
        public int? No_of_buildings {get; set;}
        public int? No_of_stories {get; set;}
        public int? Number_of_bedrooms {get; set;}
        public int? Number_of_units {get; set;}
        public decimal? Partial_bath_count {get; set;}
        public bool Pool {get ;set;}
        public string? Property_type {get; set;}
        public string? Roof_cover {get; set;}
        public string? Roof_type {get; set;}
        public string? Sewer {get; set;}
        public decimal? Site_area_acres {get; set;}
        public string? Style {get; set;}
        public string? Subdivision {get; set;}
        public decimal? Total_bath_count {get; set;}
        public string? Water {get; set;}
        public int? Year_built {get; set;}
        public string? Zoning {get; set;}

        public void SetBaths() =>
            Total_bath_count = Partial_bath_count + Full_bath_count;

    }

}