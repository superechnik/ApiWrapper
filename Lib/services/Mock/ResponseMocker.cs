using System.Linq;
using Lib.Models.HouseCanary;
using Faker;

namespace Lib.Services.Mock
{
    public class ResponseMocker : IResponseMocker
    {
        public Root MockResponse()
        {
            Result result = new()
            {
                Assessment = CreateAssessment(),
                Property = CreateProperty()
            };

            result.Assessment.RoundDollarValues();
            result.Property.SetBaths();

            PropertyDetails propertyDetails = new()
            {
                Result = result,
                Api_code = 0,
                Api_code_description = "ok"
            };


            return new Root()
            {
                PropertyDetails = propertyDetails
            };
        }

        private static Assessment CreateAssessment() =>
            new()
            {
                Apn = Identification.UsPassportNumber(),
                Assessment_year = RandomNumber.Next(2018, 2021),
                Tax_amount = (decimal?)(RandomNumber.Next(300000, 2000000) / 2.1),
                Tax_year = 2021,
                Total_assessed_value = (decimal?)(RandomNumber.Next(600000, 4000000) / 2.1),

            };

        private static Property CreateProperty() =>
            new()
            {
                Air_conditioning = Faker.Enum.Random<HouseCanaryData.YesNo>().ToString(),
                Attic = Faker.Boolean.Random(),
                Building_area_sq_ft = RandomNumber.Next(600, 178926),
                Site_area_acres = RandomNumber.Next(1000, 2000000),
                Basement = ReadRandomIndex(HouseCanaryData.GetBasements()),
                Building_condition_score = RandomNumber.Next(1, 5),
                Building_quality_score = RandomNumber.Next(1, 5),
                Construction_type = ReadRandomIndex(HouseCanaryData.GetConstructionTypes()),
                Exterior_walls = ReadRandomIndex(HouseCanaryData.GetExteriorWalls()),
                Fireplace = Faker.Boolean.Random(),
                Full_bath_count = RandomNumber.Next(1, 5),
                Garage_parking_of_cars = RandomNumber.Next(0, 12),
                Garage_type_parking = ReadRandomIndex(HouseCanaryData.GetGarageTypeParking()),
                Heating = ReadRandomIndex(HouseCanaryData.GetHeating()),
                No_of_buildings = RandomNumber.Next(1, 3),
                No_of_stories = RandomNumber.Next(1, 4),
                Number_of_bedrooms = RandomNumber.Next(1, 12),
                Number_of_units = RandomNumber.Next(1, 50),
                Partial_bath_count = RandomNumber.Next(0, 3),
                Pool = Faker.Boolean.Random(),
                Property_type = ReadRandomIndex(HouseCanaryData.GetPropertyTypes()),
                Roof_cover = ReadRandomIndex(HouseCanaryData.GetRoofCovers()),
                Roof_type = ReadRandomIndex(HouseCanaryData.GetRoofTypes()),
                Sewer = Faker.Enum.Random<HouseCanaryData.Sewer>().ToString(),
                Style = ReadRandomIndex(HouseCanaryData.GetStyles()),
                Subdivision = string.Join(" ", Lorem.Words(2).ToArray()),
                Water = Faker.Enum.Random<HouseCanaryData.Water>().ToString(),
                Year_built = RandomNumber.Next(1720, 2021),
                Zoning = ReadRandomIndex(HouseCanaryData.GetZones())
            };

        private static string ReadRandomIndex(string[] arr) =>
            arr[RandomNumber.Next(0, arr.Length - 1)];

    }
}
