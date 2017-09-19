using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemoApp.Model;

namespace MVVMDemoApp.Providers
{
    public class TelevisionSeriesProvider : ITelevisionSeriesProvider
    {
        private static readonly IEnumerable<TelevisionSeries> _televisionSeries = new[]
        {
            new TelevisionSeries("Game of Thrones", new[] { "David Benioff", "D. B. Weiss" }, new[] { Genre.Fantasy, Genre.Drama}),
            new TelevisionSeries("Twin Peaks", new[] { "Mark Frost", "David Lynch" }, new[] { Genre.Drama, Genre.Mystery }),
            new TelevisionSeries("Big Little Lies", new[] { "David E. Kelley" }, new[] {Genre.Comedy, Genre.Drama }),
            new TelevisionSeries("Fargo", new[] { "Noah Hawley" }, new[] { Genre.Comedy, Genre.Drama }),
            new TelevisionSeries("Legion", new[] { "Noah Hawley"}, new[] { Genre.ScienceFiction, Genre.Drama }),
            new TelevisionSeries("The Handmaid's Tale", new[] { "Bruce Miller" }, new[] { Genre.Drama })
        };

        public Task<IEnumerable<TelevisionSeries>> GetTelevisionSeriesAsync()
        {
            return Task.FromResult(_televisionSeries);
        }
    }
}
