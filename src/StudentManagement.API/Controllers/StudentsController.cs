using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Services;
using System;
using System.Threading.Tasks;

namespace StudentManagement.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
            => Ok(await _studentService.GetAsync());

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] AddOrUpdateStudentDto dto)
            => Ok(await _studentService.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] AddOrUpdateStudentDto dto, Guid id)
            => Ok(await _studentService.UpdateAsync(dto, id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _studentService.DeleteAsync(id);
            
            return NoContent();
        }
    }
}