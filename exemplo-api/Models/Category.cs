using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace exemplo_api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigaótio")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter entre 3 e 60 carcteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 carcteres")]
        public string Title { get; set; }
    }
}
