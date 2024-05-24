using FizzBuzz.Api.Application.Interfaces;
using FizzBuzz.Api.Domain.Entities;
using FizzBuzz.Api.Domain.Services;

namespace FizzBuzz.Api.Application.Services
{
    public class FizzBuzzAppService : IFizzBuzzAppService
    {
        private readonly FizzBuzzService _fizzBuzzService;

        public FizzBuzzAppService(FizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        public FizzBuzzSeries GenerateSeries(int startNumber, int endNumber)
        {
            return _fizzBuzzService.GenerateSeries(startNumber, endNumber);
        }
    }
}
