using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = Lib.models;
using Faker;

namespace Fake
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        enum YesNo
        {   Yes,
            No
        }

        enum Sewer 
        {   Municipal, 
            None, 
            Storm, 
            Septic, 
            Yes 
        }
        
        enum Water
        {   Cistern, 
            Municipal, 
            None, 
            Spring, 
            Well
        }
   

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] string address, int zipCode)
        {
            
            var assessment = new models.propertyDetails.Assessment()
            {
                Apn = Faker.Identification.UsPassportNumber(),
                Assessment_year = Faker.RandomNumber.Next(2018,2021),
                Tax_amount = (decimal?)(Faker.RandomNumber.Next(300000,2000000)/2.1),
                Tax_year = 2021,
                Total_assessed_value = (decimal?)(Faker.RandomNumber.Next(600000,4000000)/2.1),
            
            };

            //round
            assessment.Tax_amount = decimal.Round(assessment.Tax_amount.Value,2);
            assessment.Total_assessed_value = decimal.Round(assessment.Total_assessed_value.Value, 2);

            var basements = new string[]
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

            var constructionTypes = new string[]
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

            var exteriorWalls = new string[]
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

            var garageTypeParking = new string[]
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

            var heating = new string[]
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

            var propertyTypes = new string[]
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

            var roofCovers = new string[]
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

            var roofTypes = new string[]
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

            var styles = new string[]
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

            var zones = new string[]
            {
                "3R",
                "2B",
                "A1",
                "C2",
                null
            };

            var property = new models.propertyDetails.Property()
            {
                Air_conditioning = Faker.Enum.Random<YesNo>().ToString(),
                Attic = Faker.Boolean.Random(),
                Building_area_sq_ft = Faker.RandomNumber.Next(600, 178926),
                Site_area_acres = Faker.RandomNumber.Next(1000, 2000000),
                Basement = basements[Faker.RandomNumber.Next(0, basements.Length-1)],
                Building_condition_score = Faker.RandomNumber.Next(1, 5),
                Building_quality_score = Faker.RandomNumber.Next(1, 5),
                Construction_type = constructionTypes[Faker.RandomNumber.Next(0, constructionTypes.Length-1)],
                Exterior_walls = exteriorWalls[Faker.RandomNumber.Next(0, exteriorWalls.Length-1)],
                Fireplace = Faker.Boolean.Random(),
                Full_bath_count = Faker.RandomNumber.Next(1, 5),
                Garage_parking_of_cars = Faker.RandomNumber.Next(0, 12),
                Garage_type_parking = garageTypeParking[Faker.RandomNumber.Next(0, garageTypeParking.Length-1)],
                Heating = heating[Faker.RandomNumber.Next(0, heating.Length-1)],
                No_of_buildings = Faker.RandomNumber.Next(1, 3),
                No_of_stories = Faker.RandomNumber.Next(1, 4),
                Number_of_bedrooms = Faker.RandomNumber.Next(1, 12),
                Number_of_units = Faker.RandomNumber.Next(1, 50),
                Partial_bath_count = Faker.RandomNumber.Next(0, 3),
                Pool = Faker.Boolean.Random(),
                Property_type = propertyTypes[Faker.RandomNumber.Next(0, propertyTypes.Length-1)],
                Roof_cover = roofCovers[Faker.RandomNumber.Next(0, roofCovers.Length-1)],
                Roof_type = roofTypes[Faker.RandomNumber.Next(0, roofTypes.Length-1)],
                Sewer = Faker.Enum.Random<Sewer>().ToString(),
                Style = styles[Faker.RandomNumber.Next(0, styles.Length-1)],
                Subdivision = string.Join(" ", Faker.Lorem.Words(2).ToArray()),
                Water = Faker.Enum.Random<Water>().ToString(),
                Year_built = Faker.RandomNumber.Next(1720,2021),
                Zoning = zones[Faker.RandomNumber.Next(0, zones.Length-1)]
            };

            property.Total_bath_count = property.Partial_bath_count + property.Full_bath_count;
            
            var result = new models.propertyDetails.Result()
            {
                Assessment = assessment,
                Property = property
            };

            var propertyDetails = new models.propertyDetails.PropertyDetails()
            {
                Result = result,
                Api_code = 0,
                Api_code_description = "ok"
            };

            var response = new models.propertyDetails.Root()
            {
                PropertyDetails = propertyDetails
            };
            

            return await Task.Run(() => Ok(response));
        }

    }
}