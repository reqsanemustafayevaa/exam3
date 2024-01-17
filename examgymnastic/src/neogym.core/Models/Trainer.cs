using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neogym.core.Models
{
    public class Trainer:BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(80)]
        public string InstaUrl { get; set; }
        [Required]
        [StringLength(80)]
        public string FbUrl { get; set; }
        [Required]
        [StringLength(80)]
        public string TwitterUrl { get; set; }
        [StringLength(100)]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; } 
       
    }
}
