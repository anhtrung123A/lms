using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; } = string.Empty;
        [Required]
        public Guid? TestId { get; set; }
        [ForeignKey("TestId")]
        public Test? Test { get; set; }
        public ICollection<Answer>? Answers {get; set;} = new List<Answer>();
    }
}