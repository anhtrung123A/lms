using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow ;
        public int TimeLimit { get; set; }
        [Required]
        public Guid ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]
        public Classroom? Classroom { get; set; }
    }
}