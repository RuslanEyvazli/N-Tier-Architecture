using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.Questions.Create
{
    public class QuestionCreateResponseDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid QuestionSetId { get; set; }
        public byte Point { get; set; }

    }
}
