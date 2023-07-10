using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.GetById;
using Quizer.Models.DTOs.Questions.SaveAnswer;
using Quizer.Models.DTOs.Questions.Save;
using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Core.Services
{
    public interface IQuestionService 
    {
        public QuestionCreateResponseDto Create(QuestionCreateDto request);
        public void Save(QuestionSaveDto request);
        public QuestionGetByIdResponseDto GetById(int id);

        public QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request);
        public void RemoveAnswer(Guid id);

    }
}
