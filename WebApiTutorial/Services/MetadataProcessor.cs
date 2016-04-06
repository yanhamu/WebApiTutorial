using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace WebApiTutorial.Services
{
    public class MetadataProcessor
    {
        private readonly IEnumerable<IMetadataHandler> handlers;

        public MetadataProcessor(IEnumerable<IMetadataHandler> handlers)
        {
            this.handlers = handlers;
        }

        public void Process(HttpResponseMessage result)
        {
            var content = result.Content as ObjectContent;
            if (content == null)
                return;

            handlers
                .Where(h => h.CanProcess(content.ObjectType))
                .Aggregate(content, (r, h) => h.Handle(r));
        }
    }
}