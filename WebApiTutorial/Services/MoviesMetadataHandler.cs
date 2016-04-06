using System.Collections.Generic;
using WebApiTutorial.Model;

namespace WebApiTutorial.Services
{
    public class MoviesMetadataHandler : MetadataHandler<List<Movie>>
    {
        private readonly MovieMetadataHandler movieHandler;

        public MoviesMetadataHandler(MovieMetadataHandler movieHandler)
        {
            this.movieHandler = movieHandler;
        }
        public override void Process(List<Movie> content)
        {
            content.ForEach(m => movieHandler.Process(m));
        }
    }
}