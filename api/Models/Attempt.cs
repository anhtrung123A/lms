using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Attempt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DoneAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public AppUser? Student { get; set; }
        [Required]
        public Guid TestId { get; set; }
        [ForeignKey("TestId")]
        public Test? Test { get; set; }
        public float Mark { get; set; }
        public ICollection<AttemptDetail> AttemptDetail {get; set;} = new List<AttemptDetail>();
    }
}