using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AttemptDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }
        [Required]
        public Guid AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public Answer? Answer { get; set; }
        [Required]
        public Guid AttemptId { get; set; }
        [ForeignKey("AttemptId")]
        public Attempt? Attempt { get; set; }
    }
}