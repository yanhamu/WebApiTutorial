using System.Collections.Generic;
using WebApiTutorial.Model;

namespace WebApiTutorial.Services
{
    public class DirectorService
    {
        public List<Director> GetAll()
        {
            var tarantino = new Director() { Id = 1, FirstName = "Quentin", LastName = "Tarantino" };
            var scott = new Director() { Id = 2, FirstName = "Scott", LastName = "Ridley" };
            return new List<Director>() { tarantino, scott };
        }
    }
}