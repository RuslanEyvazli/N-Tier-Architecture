using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Repositories;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.Save;
using Quizer.Models.DTOs.Questions.SaveAnswer;
using Quizer.Models.Entities;
using static Quizer.Core.Extensions.Extention;

namespace Quzier.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;
        // private readonly IRepository<Question> repository;

        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
            // this.repository = repository;
        }

        [HttpPost()]
        public IActionResult Create(QuestionCreateDto request)
        {
            var response = questionService.Create(request);

            return Ok(response);
        }
        [HttpPost("save")]
        public IActionResult Save(QuestionSaveDto request)
        {
           questionService.Save(request);

            return NoContent();
        }
        [HttpPost("save-answer")]
        public IActionResult SaveAnswer(QuestionSaveAnswerDto request)
        {
            var response = questionService.SaveAnswer(request);

            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = questionService.GetById(id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            questionService.Remove(id);

            return NoContent();

        }

        [HttpDelete("remove-answer/{id}")]
        public IActionResult RemoveAnswer(Guid id)
        {
            questionService.RemoveAnswer(id);

            return NoContent();

        }

        //[HttpPatch("{id}")]
        //public IActionResult ChangeQuestion(Guid id, string text)
        //{
        //    var entity = repository.GetFirst(m => m.Id == id);

        //    repository.Edit(entity, entry =>
        //    {
        //        entry.SetValue(m => m.Text, text);
        //    });
        //    return NoContent();
        //}
        //[HttpPut("{id}")]
        //public IActionResult ChangeQuestion(Guid id, string text)
        //{
        //    var entity = repository.GetFirst(m => m.Id == id);
        //    entity.Text = "";
        //    entity.QuestionSetId = Guid.NewGuid();

        //    repository.Edit(entity);

        //    return NoContent();
        //}
    }
    }
