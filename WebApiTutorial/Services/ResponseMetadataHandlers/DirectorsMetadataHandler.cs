using System.Collections.Generic;
using WebApiTutorial.Model;

namespace WebApiTutorial.Services.ResponseMetadataHandlers
{
    public class DirectorsMetadataHandler : MetadataHandler<List<Director>>
    {
        private readonly DirectorMetadataHandler directorHandler;

        public DirectorsMetadataHandler(DirectorMetadataHandler directorHandler)
        {
            this.directorHandler = directorHandler;
        }
        public override void Process(List<Director> content)
        {
            content.ForEach(d => directorHandler.Process(d));
        }
    }
}