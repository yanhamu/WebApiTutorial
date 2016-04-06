using WebApiTutorial.Model;

namespace WebApiTutorial.Services
{
    public class MovieMetadataHandler : MetadataHandler<Movie>
    {
        public override void Process(Movie content)
        {
            content.Url = "test";
        }
    }
}