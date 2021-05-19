using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketAuction.Api.Models
{
    public class Make
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; private set; }


        public IList<Model> Models { get; private set; }

        public Make(int id, string name)
        {
            Id = id > 0 ? id : throw new ArgumentException();
            Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentException(); ;
        }
    }
}
