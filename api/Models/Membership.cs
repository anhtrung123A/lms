using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Membership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]
        public Classroom? Classroom { get; set; }
        [Required]
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey("StudentId")]
        public AppUser? Student { get; set; }
        public DateTime SendAt { get; set; } = DateTime.UtcNow;
        public bool IsApproved { get; set; }
    }
}