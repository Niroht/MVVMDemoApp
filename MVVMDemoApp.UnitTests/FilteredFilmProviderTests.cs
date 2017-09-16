using NUnit.Framework;
using MVVMDemoApp.Providers;
using Moq;
using MVVMDemoApp.Model;
using System.Linq;
using System.Collections.Generic;

namespace MVVMDemoApp.UnitTests
{
    [TestFixture]
    public class FilteredFilmProviderTests
    {
        [Test]
        public void ReturnEmptyListIfNullResults()
        {
            // arrange
            var tc = new TestContext();
            tc.FilmProviderMock.Setup(x => x.GetFilms()).Returns<IEnumerable<Film>>(null);

            // act
            var result = tc.Sut.GetFilms(new FilmFilterParameters());

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void ReturnEmptyListIfNoResultsAtAll()
        {
            // arrange
            var tc = new TestContext();
            tc.FilmProviderMock.Setup(x => x.GetFilms()).Returns(Enumerable.Empty<Film>());

            // act
            var result = tc.Sut.GetFilms(new FilmFilterParameters());

            // assert
            Assert.IsEmpty(result);
        }

        [TestCase("AAA", Description = "Exact Match")]
        [TestCase("aaa", Description = "Case Insentitive")]
        [TestCase("AA", Description = "Partial Match")]
        [TestCase("aa", Description =" Case Insensitive Partial Match")]
        public void FilterByTitle(string filterTerm)
        {
            // arrange
            var films = new[] {
                new Film("AAA", new[] { "ZZZ", "ZZZ"}, new[] { Genre.Action}),
                new Film("BBB", new[] { "ZZZ", "ZZZ"}, new[] { Genre.Action})
            };

            var tc = new TestContext();
            tc.FilmProviderMock.Setup(x => x.GetFilms()).Returns(films);

            // act
            var result = tc.Sut.GetFilms(new FilmFilterParameters() { Title = filterTerm });

            // assert
            Assert.AreEqual(films.First(), result.First());
            Assert.AreEqual(1, result.Count());
        }

        [TestCase("AAA", Description = "Exact Match")]
        [TestCase("aaa", Description = "Case Insentitive")]
        [TestCase("AA", Description = "Partial Match")]
        [TestCase("aa", Description = " Case Insensitive Partial Match")]
        [TestCase("BBB", Description = "Finds Second Director")]
        public void FilterByDirector(string filterTerm)
        {
            // arrange
            var films = new[] {
                new Film("ZZZ", new[] { "AAA", "BBB"}, new[] { Genre.Action}),
                new Film("ZZZ", new[] { "CCC", "DDD"}, new[] { Genre.Action})
            };

            var tc = new TestContext();
            tc.FilmProviderMock.Setup(x => x.GetFilms()).Returns(films);

            // act
            var result = tc.Sut.GetFilms(new FilmFilterParameters() { Director = filterTerm });

            // assert
            Assert.AreEqual(films.First(), result.First());
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void FilterByGenre()
        {
            // arrange
            var films = new[] {
                new Film("ZZZ", new[] { "AAA", "BBB"}, new[] { Genre.Comedy, Genre.Action}),
                new Film("ZZZ", new[] { "AAA", "BBB"}, new[] { Genre.Action}),
                new Film("ZZZ", new[] { "CCC", "DDD"}, new[] { Genre.ScienceFiction})
            };

            var tc = new TestContext();
            tc.FilmProviderMock.Setup(x => x.GetFilms()).Returns(films);

            // act
            var result = tc.Sut.GetFilms(new FilmFilterParameters() { Genre = Genre.Action });

            // assert
            Assert.AreEqual(films.First(), result.First());
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void CacheResults()
        {
            // arrange
            var films = new[] {
                new Film("AAA", new[] { "ZZZ", "ZZZ"}, new[] { Genre.Action}),
                new Film("BBB", new[] { "ZZZ", "ZZZ"}, new[] { Genre.Action})
            };

            var tc = new TestContext();
            tc.FilmProviderMock.Setup(x => x.GetFilms()).Returns(films);

            tc.Sut.GetFilms(new FilmFilterParameters());

            // act
            var result = tc.Sut.GetFilms(new FilmFilterParameters());

            // assert
            tc.FilmProviderMock.Verify(x => x.GetFilms(), Times.Once);
        }

        [Test]
        public void ReloadCache()
        {
            // arrange
            var films = new[] {
                new Film("AAA", new[] { "ZZZ", "ZZZ"}, new[] { Genre.Action}),
                new Film("BBB", new[] { "ZZZ", "ZZZ"}, new[] { Genre.Action})
            };

            var tc = new TestContext();
            tc.FilmProviderMock.Setup(x => x.GetFilms()).Returns(films);

            tc.Sut.GetFilms(new FilmFilterParameters());

            // act
            var result = tc.Sut.GetFilms(new FilmFilterParameters(), reload: true);

            // assert
            tc.FilmProviderMock.Verify(x => x.GetFilms(), Times.Exactly(2));
        }

        [Test]
        public void FilteringDoesNotRemoveResultsFromNextFilter()
        {
            // arrange
            var films = new[] {
                new Film("AAA", new[] { "ZZZ", "ZZZ"}, new[] { Genre.Action}),
                new Film("BBB", new[] { "ZZZ", "ZZZ"}, new[] { Genre.Action})
            };

            var tc = new TestContext();
            tc.FilmProviderMock.Setup(x => x.GetFilms()).Returns(films);

            tc.Sut.GetFilms(new FilmFilterParameters() { Title = "AAA" });

            // act
            var result = tc.Sut.GetFilms(new FilmFilterParameters() { Title = "BBB" });

            // assert
            Assert.AreEqual(films.ElementAt(1), result.First());
            Assert.AreEqual(1, result.Count());
        }

        private class TestContext
        {
            public TestContext()
            {
                FilmProviderMock = new Mock<IFilmProvider>();

                Sut = new FilteredFilmProvider(FilmProviderMock.Object);
            }

            public FilteredFilmProvider Sut { get; }

            public Mock<IFilmProvider> FilmProviderMock { get; }
        }
    }
}
