using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class CarModel
    {
        [Key]
        [Display(Name = "Car model id")]
        public int CarModelId { get; set; }
        [Display(Name = "Car model name")]
        public string Name { get; set; }
        [Display(Name = "Car model description")]
        public string Description { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
