using System;
using System.Net.Http;

namespace WebApiTutorial.Services
{
    public interface IMetadataHandler
    {
        bool CanProcess(Type contentType);
        ObjectContent Handle(ObjectContent responseMessage);
    }
}
