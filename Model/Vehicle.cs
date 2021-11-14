using System.Security.AccessControl;
using System.Security.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string VehicleType { get; set; }
        [MaxLength(50)]
        public string Make { get; set; }
    }
}