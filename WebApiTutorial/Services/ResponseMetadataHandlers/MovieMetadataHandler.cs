using WebApiTutorial.Model;

namespace WebApiTutorial.Services.ResponseMetadataHandlers
{
    public class MovieMetadataHandler : MetadataHandler<Movie>
    {
        private readonly DirectorMetadataHandler directorHandler;

        public MovieMetadataHandler(DirectorMetadataHandler directorHandler)
        {
            this.directorHandler = directorHandler;
        }

        public override void Process(Movie content)
        {
            content.Links = new Links() { Self = "api/movies/" + content.Id };
            content.Directors.ForEach(d => directorHandler.Process(d));
        }
    }
}