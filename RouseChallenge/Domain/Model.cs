using System;
using System.ComponentModel.DataAnnotations;

namespace RouseChallenge.Domain
{
    public class Model
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; private set; }

        public int MakeId { get; set; }
        public Make Make { get; private set; }

        public Model(int id, string name, int makeId)
        {
            Id = id > 0 ? id : throw new ArgumentException();
            Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentException(); ;
            MakeId = makeId >= 0 ? makeId : throw new ArgumentException(); ;
        }
    }
}
