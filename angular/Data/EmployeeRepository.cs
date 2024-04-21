using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
namespace angular.Data
{
	public class EmployeeRepository
	{
		private readonly Applicationdbcontext applicationdbcontext;
		public EmployeeRepository(Applicationdbcontext applicationdbcontext) {

			this.applicationdbcontext = applicationdbcontext;
				
		}

		public async Task AddEmployeeAsync(Employee employee)
		{
			await applicationdbcontext.Set<Employee>().AddAsync(employee);
			await applicationdbcontext.SaveChangesAsync();
		}

		public async Task<List<Employee>> getAllEmployeeAsync()
		{
			return await applicationdbcontext.Employees.ToListAsync();
			
		}

		public async Task <Employee>GetemployeebyIdAsync(int id)
		{
			return await applicationdbcontext.Employees.FindAsync(id);


		}

		public async Task getEmployeebyId(int id, Employee model)
		{
			var employee = await applicationdbcontext.Employees.FindAsync(id);

			if(employee	==null)
			{
				throw new Exception("employee not found");
			}
			employee.Name = model.Name;
			
			employee.phone = model.phone;
			employee.age = model.age;
			employee.salary = model.salary;

		 await applicationdbcontext.SaveChangesAsync();
			

		}
		public async Task DeleteEmployeebyId(int id)
		{
			var employee = await applicationdbcontext.Employees.FindAsync(id);

			if (employee == null)
			{
				throw new Exception("employee not found");
			}
			applicationdbcontext.Employees.Remove(employee);
			applicationdbcontext.SaveChanges();
		}
	}
}
