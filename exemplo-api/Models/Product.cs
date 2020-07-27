using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace exemplo_api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigaótio")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter entre 3 e 60 carcteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 carcteres")]
        public string Title { get; set; }

        [MaxLength(1020, ErrorMessage = "Este campo deve ter no máximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }  
    }
}
