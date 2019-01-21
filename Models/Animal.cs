using System.Runtime.Serialization;

namespace ConsoleApp4.Models
{
    [DataContract(Name = "animal")]
    public class AnimalDto
    {
        public AnimalDto(string name)
        {
            Name = name;
        }

        [DataMember(Name = "name")] public string Name { get; set; }
    }
}