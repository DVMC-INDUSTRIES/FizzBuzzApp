namespace FizzBuzz.Api.Domain.Entities
{
    public class FizzBuzzSeries
    {
        public int StartNumber { get; set; }
        public int EndNumber { get; set; }
        public List<string> Series { get; set; } = new List<string>();
    }
}
