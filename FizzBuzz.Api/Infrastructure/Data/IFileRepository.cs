using FizzBuzz.Api.Domain.Entities;
using System.Threading.Tasks;

namespace FizzBuzz.Api.Infrastructure.Data
{
    public interface IFileRepository
    {
        Task SaveSeriesAsync(FizzBuzzSeries series);
    }
}
