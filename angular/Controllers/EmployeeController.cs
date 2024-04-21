using angular.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace angular.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly EmployeeRepository employeeRepository;

		public EmployeeController(EmployeeRepository employeeRepository) {
			this.employeeRepository = employeeRepository;	
				}
		[HttpPost]
		public async Task<ActionResult> AddEmployeeAsync([FromBody] Employee Model)
		{
			await employeeRepository.AddEmployeeAsync(Model);
			return Ok();
		}


		[HttpGet]

		public async Task<ActionResult> Getemployeelist()
		{
			var employeelist = await employeeRepository.getAllEmployeeAsync();
			return Ok(employeelist);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetemployeebyIdAsync([FromRoute] int id)
		{
			var employee = await employeeRepository.GetemployeebyIdAsync(id);
			return Ok(employee);
		}

		[HttpPut ("{id}")]
		
		public async Task<ActionResult> UpdatEmployeeAsync([FromRoute] int id, [FromBody] Employee model)
		{
			await employeeRepository.getEmployeebyId(id, model);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteEmployeeAsync([FromRoute] int id)
		{
			await employeeRepository.DeleteEmployeebyId(id);
			return Ok();
		}

	}
}
