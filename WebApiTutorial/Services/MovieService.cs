using System.Collections.Generic;
using WebApiTutorial.Model;

namespace WebApiTutorial.Services
{
    public class MovieService
    {
        public List<Movie> GetAll()
        {
            var tarantino = new Director() { Id = 1, FirstName = "Quentin", LastName = "Tarantino" };
            var scott = new Director() { Id = 2, FirstName = "Scott", LastName = "Ridley" };

            var alien = new Movie() { Id = 1, Genre = "Scifi", Title = "Alien" };
            alien.Directors.Add(scott);

            var martian = new Movie() { Id = 2, Genre = "Scifi", Title = "Martian" };
            martian.AddDirector(scott);

            var pulp = new Movie() { Id = 3, Genre = "Thriler", Title = "Pulp Fiction" };
            pulp.AddDirector(tarantino);

            return new List<Movie>() { alien, martian, pulp };
        }
    }
}