using System.Collections;
using System.Collections.Generic;

namespace Melea.Models
{
    public class Blend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Volume> Volumes { get; set; }
    }
}