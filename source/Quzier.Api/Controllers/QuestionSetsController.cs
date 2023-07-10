using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Repositories.Special;
using Quizer.Core.Services;
using Quizer.Models.DTOs.QuestionSets.Create;

namespace Quzier.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionSetsController : ControllerBase
    {
        private readonly IQuestionSetService questionSetService;

        public QuestionSetsController(IQuestionSetService questionSetService)
        {
            this.questionSetService = questionSetService;
        }
        [HttpPost]
        public  IActionResult Create(QuestionSetCreateDto request)
        {
            var response = questionSetService.Create(request);

            return Ok(response);
        }
    }
}
