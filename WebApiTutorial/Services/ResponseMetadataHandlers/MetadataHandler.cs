using System;
using System.Net.Http;

namespace WebApiTutorial.Services.ResponseMetadataHandlers
{
    public abstract class MetadataHandler<T> : IMetadataHandler where T : class
    {
        public ObjectContent Handle(ObjectContent content)
        {
            Process(content.Value as T);
            return content;
        }

        public bool CanProcess(Type contentType)
        {
            return contentType == typeof(T);
        }

        public abstract void Process(T content);
    }
}