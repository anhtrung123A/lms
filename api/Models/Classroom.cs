using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace api.Models
{
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ClassName { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [Required]
        public string TeacherId {get; set;} = string.Empty;
        [ForeignKey("TeacherId")]
        public AppUser Teacher { get; set; }
    }
}