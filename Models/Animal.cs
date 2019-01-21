using System.Runtime.Serialization;

namespace ConsoleApp4.Models
{
    public class AnimalDto
    {
        public AnimalDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}