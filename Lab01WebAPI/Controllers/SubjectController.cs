using Lab01Lib;
using Lab01WebAPI.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab01WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetSubjects()
        {
            var model= SubjectDAO.GetSubjects();
            return Ok(model);
        }
        [HttpPost]
        public async Task<ActionResult> addSubject(Subject subject)
        {
            SubjectDAO.saveSubject(subject);
            return Ok();
        }
        [HttpDelete("{code}")]
        public async Task<ActionResult> removeSubject(string code)
        {
            SubjectDAO.deleteSubject(code);
            return Ok();
        }
    }
}
