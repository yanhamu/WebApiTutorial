using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApiTutorial.Services;

namespace WebApiTutorial.Handlers
{
    public class MetadataResponseHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base
                .SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var metadataHandler = request
                        .GetDependencyScope()
                        .GetService(typeof(MetadataProcessor)) as MetadataProcessor;

                    metadataHandler.Process(task.Result);

                    return task.Result;
                });
        }
    }
}