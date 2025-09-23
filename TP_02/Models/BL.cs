using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBTSWE2_TP02.Models
{
    //Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179
    public class BL
    {
        public int Id { get; set; }

        [Required]
        public string Numero { get; set; } = string.Empty;

        [Required]
        public string Consignee { get; set; } = string.Empty;

        [Required]
        public string Navio { get; set; } = string.Empty;

        public ICollection<Container> Containers { get; set; } = new List<Container>();
    }
}
