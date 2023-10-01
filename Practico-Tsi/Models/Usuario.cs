using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practico_Tsi.Models;

public class Usuario
{
    [Key][Required] public int Id { get; set; }
    [Required] public string Nombre { get; set; }
    [Required] public string Alias { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Biografia { get; set; }

}
