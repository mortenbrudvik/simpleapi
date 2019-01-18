using System.Runtime.Serialization;

namespace ConsoleApp4
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