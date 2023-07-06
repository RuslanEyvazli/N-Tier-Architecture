using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.GetById;
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
        public QuestionCreateReponseDto Create(QuestionCreateDto request);
        public QuestionGetByIdReponseDto GetById(int id);
    }
}
