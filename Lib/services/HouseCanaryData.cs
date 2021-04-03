namespace Lib.Services.Mock
{
    public static class HouseCanaryData
    {
        public enum YesNo
        {
            Yes,
            No
        }

        public enum Sewer
        {
            Municipal,
            None,
            Storm,
            Septic,
            Yes
        }

        public enum Water
        {
            Cistern,
            Municipal,
            None,
            Spring,
            Well
        }

        public static string[] GetBasements() =>
            new string[]
            {
                    "Basement(not specified)",
                    "Daylight",
                    "Full",
                    "Daylight",
                    "Partial",
                    "Full Basement",
                    "Improved Basement(Finished)",
                    "No Basement",
                    "Partial Basement",
                    "Unfinished Basement",
                    null
            };

        public static string[] GetConstructionTypes() =>
            new string[]
            {
                    "Adobe",
                    "Brick",
                    "Concrete",
                    "Concrete Block",
                    "Dome",
                    "Frame",
                    "Heavy",
                    "Light",
                    "Log",
                    "Manufactured",
                    "Other",
                    "Masonry",
                    "Metal",
                    "Steel",
                    "Stone",
                    "Tilt-up (pre-cast concrete)",
                    "Wood",
                    "Mixed",
                    null
            };

        public static string[] GetExteriorWalls() =>
            new string[]
            {
                "Adobe",
                "Asbestos shingle",
                "Block",
                "Brick",
                "Brick veneer",
                "Combination",
                "Composition",
                "Concrete",
                "Concrete Block",
                "Glass",
                "Log",
                "Marble",
                "Masonry",
                "Metal",
                "Other",
                "Rock",
                "Stone",
                "Shingle (Not Wood)",
                "Siding (Alum/Vinyl)",
                "Stucco",
                "Tile",
                "Tilt-up (pre-cast concrete)",
                "Wood",
                "Wood Shingle",
                "Wood Siding",
                null
            };

        public static string[] GetGarageTypeParking() =>
            new string[]
            {
                "Attached Garage",
                "Built-in",
                "Carport",
                "Covered",
                "Detached Garage",
                "Garage",
                "Mixed",
                "None",
                "Offsite",
                "Open",
                "Parking Lot",
                "Parking Structure",
                "Paved/Surfaced",
                "Pole",
                "Ramp",
                "Tuckunder",
                "Underground/Basement",
                "Unimproved",
                "Yes",
                null
            };

        public static string[] GetHeating() =>
            new string[]
            {
                "Baseboard",
                "Central",
                "Coal",
                "Convection",
                "Electric",
                "Floor/Wall",
                "Forced air unit",
                "Gas",
                "Geo-thermal",
                "Gravity",
                "Heat Pump",
                "Hot Water",
                "None",
                "Oil",
                "Other",
                "Partial",
                "Propane",
                "Radiant",
                "Solar",
                "Space/Suspended",
                "Steam",
                "Vent",
                "Wood Burning",
                "Yes",
                "Zone",
                null
            };

        public static string[] GetPropertyTypes() =>
            new string[]
            {
                "Single Family Residential",
                "Townhouse",
                "Condominium",
                "Manufactured/Mobile Home",
                "Multi-Family",
                "Land",
                "Timeshare",
                "Commercial",
                "Other",
                null
            };

        public static string[] GetRoofCovers() =>
            new string[]
            {
                "Aluminum",
                "Asbestos",
                "Asphalt",
                "Bermuda",
                "Built-up",
                "Composition Shingle",
                "Concrete",
                "Fiberglass",
                "Gravel/Rock",
                "Gypsum",
                "Masonite/ Cement Shake",
                "Metal",
                "Other",
                "Roll Composition",
                "Slate",
                "Steel",
                "Shingle (Not Wood)",
                "Tar & Gravel",
                "Tile",
                "Urethane",
                "Wood",
                "Wood Shake/ Shingles",
                null
            };

        public static string[] GetRoofTypes() =>
            new string[]
            {
                "Bowstring Truss",
                "Dome",
                "Flat",
                "Gable",
                "Gable or Hip",
                "Gambrel",
                "Hip",
                "Irr/Cathedral",
                "Mansard",
                "Prestress Concrete",
                "Reinforced Concrete",
                "Rigid frm bar JT",
                "Sawtooth",
                "Shed",
                "Steel frm/truss",
                "Wood Truss",
                null
            };

        public static string[] GetStyles() =>
            new string[]
            {
                "A-Frame",
                "Bungalow",
                "Cape Cod",
                "Colonial",
                "Contemporary",
                "Conventional",
                "Cottage",
                "Custom",
                "Dome",
                "English",
                "French Provincial",
                "Georgian",
                "High-rise",
                "Historical Log Cabin/Rustic",
                "Mansion",
                "Mediterranean",
                "Modern",
                "Other",
                "Prefab",
                "Modular",
                "Raised Ranch",
                "Ranch\\Rambler",
                "Spanish",
                "Traditional",
                "Tudor",
                "Unfinished\\Under Construction",
                "Victorian",
                null
            };

        public static string[] GetZones() =>
            new string[]
            {
                "3R",
                "2B",
                "A1",
                "C2",
                null
            };
    }
}
