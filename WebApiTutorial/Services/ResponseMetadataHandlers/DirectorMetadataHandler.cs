using WebApiTutorial.Model;

namespace WebApiTutorial.Services.ResponseMetadataHandlers
{
    public class DirectorMetadataHandler : MetadataHandler<Director>
    {
        public override void Process(Director content)
        {
            content.Links = new Links() { Self = "api/directors/" + content.Id };
        }
    }
}