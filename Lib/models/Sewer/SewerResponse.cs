namespace Lib.Models.Sewer
{
    public class SewerResponse
    {
        public bool IsSeptic { get; init; }
        public string SewerType { get; init; } = "None";
    }
}