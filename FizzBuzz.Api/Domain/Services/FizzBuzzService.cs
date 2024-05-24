using FizzBuzz.Api.Domain.Entities;

namespace FizzBuzz.Api.Domain.Services
{
    public class FizzBuzzService
    {
        public FizzBuzzSeries GenerateSeries(int startNumber, int endNumber)
        {
            var series = new FizzBuzzSeries { StartNumber = startNumber, EndNumber = endNumber };

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (i % 15 == 0)
                {
                    series.Series.Add("fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    series.Series.Add("fizz");
                }
                else if (i % 5 == 0)
                {
                    series.Series.Add("buzz");
                }
                else
                {
                    series.Series.Add(i.ToString());
                }
            }

            return series;
        }
    }
}
