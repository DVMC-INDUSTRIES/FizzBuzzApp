using FizzBuzz.Api.Domain.Entities;

namespace FizzBuzz.Api.Application.Interfaces
{
    public interface IFizzBuzzAppService
    {
        FizzBuzzSeries GenerateSeries(int startNumber, int endNumber);
    }
}
