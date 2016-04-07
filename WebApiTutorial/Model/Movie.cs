using System.Collections.Generic;

namespace WebApiTutorial.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public List<Director> Directors { get; set; }
        public Links Links { get; set; }
        public Movie()
        {
            Directors = new List<Director>();
        }

        public void AddDirector(Director director)
        {
            Directors.Add(director);
            director.Movies.Add(this);
        }
    }
}