using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerWorldExplain.Models
{
    internal class Worlds
    {
        [RegularExpression("A|B", ErrorMessage = "The Gender must be either 'M' or 'F' only.")]
        public string Starport { get; set; }
        public string Size { get; set; }
        public string Atmosphere { get; set; }
        public string Hydrographics { get; set; }
        public string Population { get; set; }
        public string LawLevel { get; set; }
        public string Government { get; set; }
        public string TechLevel { get; set; }
    }
}
