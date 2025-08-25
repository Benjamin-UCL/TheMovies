using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TheMovies.Model;
using TheMovies.Data;
using TheMovies.ViewModel; // namespace for Movie_ViewModel

namespace xUnitTest
{
    public class Movie_ViewModelTests: IDisposable
    {
          
        public Movie_ViewModelTests()
        {
            // Kører FØR hver test
            if (File.Exists("movies.csv"))
                File.Delete("movies.csv");
        }

        public void Dispose()
        {
            // Kører EFTER hver test
            if (File.Exists("movies.csv"))
                File.Delete("movies.csv");
        }

        [Fact]
        public void ExampleTest()
        {
            // din test
        }
        [Fact]
        public void AddMovie_ShouldAddMovieToCollection() // Tester at en ny film bliver tilføjet korrekt
        {
            // Arrange
            var vm = new Movie_ViewModel();

            // Sæt input for ny film
            vm.newTitle = "Inception";
            vm.newDuration = 148;

            // Act
            vm.addMovieCommand.Execute(null);

            // Assert
            Assert.Single(vm.Movies);
            var movie = vm.Movies.First();
            Assert.Equal("Inception", movie.Title);
            Assert.Equal(148, movie.DurationMin);
        }


        [Fact]
        public void AddMovie_ShouldNotAdd_WhenTitleEmpty() // Tester at en film ikke bliver tilføjet hvis titlen er tom
        {
            // Arrange
            var vm = new Movie_ViewModel();
            vm.newTitle = "";
            vm.newDuration = 120;

            // Act
            bool canExecute = vm.addMovieCommand.CanExecute(null);

            // Assert
            Assert.False(canExecute);
            Assert.Empty(vm.Movies);
        }

        [Fact]
        public void AddMovie_ShouldNotAdd_WhenDurationZeroOrNegative() // Tester at en film ikke bliver tilføjet hvis varigheden er 0 eller negativ
        {
            // Arrange
            var vm = new Movie_ViewModel();
            vm.newTitle = "Test Movie";
            vm.newDuration = 0;

            // Act
            bool canExecute = vm.addMovieCommand.CanExecute(null);

            // Assert
            Assert.False(canExecute);
            Assert.Empty(vm.Movies);
        }

        [Fact]
        public void AddGenre_ShouldAddGenreToCollection()
        {
            // Arrange
            var vm = new Movie_ViewModel();
            vm.Genres.Clear();   // Rydder alt før testen

            vm.newGenreName = "Sci-Fi";

            // Act
            vm.addGenreCommand.Execute(null);

            // Assert
            Assert.Single(vm.Genres);
            Assert.Equal("Sci-Fi", vm.Genres.First().Name);
        }

        [Fact]
        public void AddGenre_ShouldNotAdd_WhenNameEmpty() // Tester at en genre ikke bliver tilføjet hvis navnet er tomt
        {
            // Arrange
            var vm = new Movie_ViewModel();
            vm.Genres.Clear();   // Rydder alt før testen
            vm.newGenreName = "";

            // Act
            bool canExecute = vm.addGenreCommand.CanExecute(null);

            // Assert
            Assert.False(canExecute);
            Assert.Empty(vm.Genres);
        }
    }
}

