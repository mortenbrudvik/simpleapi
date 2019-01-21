using System.Collections.Generic;
using System.Web.Http;

namespace ConsoleApp4
{
    public class AnimalsController : ApiController
    {
        public IEnumerable<AnimalDto> Get()
        {
            return new List<AnimalDto>(){new AnimalDto( "cat"), new AnimalDto("dog")};
        }
        
    }
}