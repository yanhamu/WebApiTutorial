using System.Net.Http;
using System.Web.Http;
using WebApiTutorial.Services;

namespace WebApiTutorial.Controllers
{
    [RoutePrefix("api/directors")]
    public class DirectorsController : ApiController
    {
        private readonly DirectorService directorService;

        public DirectorsController(DirectorService directorService)
        {
            this.directorService = directorService;
        }
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(directorService.GetAll());
        }
    }
}