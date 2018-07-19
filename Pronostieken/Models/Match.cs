using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pronostieken.Models
{
  public class Match
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [DefaultValue(false)]
    public bool IsComplete { get; set; }
  }
}
