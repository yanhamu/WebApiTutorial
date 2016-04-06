using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTutorial.Services;

namespace WebApiTutorial.Controllers
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private readonly MovieService MovieService;

        public MoviesController(MovieService movieService)
        {
            this.MovieService = movieService;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, MovieService.GetAll());
        }
    }
}
