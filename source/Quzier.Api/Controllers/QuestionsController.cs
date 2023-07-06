using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Repositories;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.Entities;
using static Quizer.Core.Extensions.Extention;

namespace Quzier.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;
        private readonly IRepository<Question> repository;

        public QuestionsController(IQuestionService questionService, IRepository<Question> repository)
        {
            this.questionService = questionService;
            this.repository = repository;
        }

        [HttpGet()]
        public IActionResult Create(QuestionCreateDto request)
        {
            var response = questionService.Create(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = questionService.GetById(id);

            return Ok(response);
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
        [HttpPut("{id}")]
        public IActionResult ChangeQuestion(Guid id, string text)
        {
            var entity = repository.GetFirst(m => m.Id == id);
            entity.Text = "";
            entity.QuestionSetId = Guid.NewGuid();

            repository.Edit(entity);

            return NoContent();
        }
    }
}
