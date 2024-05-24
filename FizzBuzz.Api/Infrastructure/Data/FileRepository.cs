using FizzBuzz.Api.Domain.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FizzBuzz.Api.Infrastructure.Data
{
    public class FileRepository : IFileRepository
    {
        private readonly string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task SaveSeriesAsync(FizzBuzzSeries series)
        {
            var seriesString = $"{DateTime.Now}: Start {series.StartNumber}, End {series.EndNumber}, Series: {string.Join(", ", series.Series)}{Environment.NewLine}";
            await File.AppendAllTextAsync(_filePath, seriesString);
        }
    }
}
