using System.Collections.Generic;

namespace Melea.Models
{
    public class RecipePost
    {
        public string Name { get; set; }
        public ICollection<Volume> Volumes { get; set; }
    }
}