using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IRepository<Todo> _todoRepository;
        public ToDoController(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _todoRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _todoRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Todo todo)
        {
            if (!ModelState.IsValid || todo == null)
                return BadRequest("Incorrect data");

            return Ok(await _todoRepository.AddAsync(todo));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Todo todo)
        {
            if (!ModelState.IsValid || todo == null)
                return BadRequest("Incorrect data");

            return Ok(await _todoRepository.UpdateAsync(todo));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            return Ok(await _todoRepository.DeleteAsync(id));
        }
    }
}
