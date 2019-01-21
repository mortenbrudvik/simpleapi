using System.Collections.Generic;
using System.Web.Http;
using ConsoleApp4.Models;

namespace ConsoleApp4.Controllers
{
    public class AnimalsController : ApiController
    {
        public IEnumerable<AnimalDto> Get()
        {
            return new List<AnimalDto>(){new AnimalDto( "cat"), new AnimalDto("dog")};
        }
        
    }
}