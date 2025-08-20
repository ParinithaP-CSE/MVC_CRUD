using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Data;
using StudentCRUD.Models;
using StudentCRUD.Models.Entities;
using System.Threading.Tasks;

namespace StudentCRUD.Controllers
{
	public class StudentController : Controller
	{
		private readonly ApplicationDBContext dBContext;
		public StudentController(ApplicationDBContext dBContext)
		{
			this.dBContext = dBContext;
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(StudentViewModel model)
		{
			var student = new Student
			{
				Name = model.Name,
				Email = model.Email,
				Phone = model.Phone,
				Subscribed = model.Subscribed,
			};
			await dBContext.Students.AddAsync(student);
			await dBContext.SaveChangesAsync();
			return RedirectToAction("List", "Student");
		}


		[HttpGet]
		public async Task<IActionResult> List()
		{
			var students = await dBContext.Students.ToListAsync();
			return View(students);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var student = await dBContext.Students.FindAsync(id);
			return View(student);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Student vewModel)
		{
			var student = await dBContext.Students.FindAsync(vewModel.Id);
			if (student != null)
			{
				student.Name = vewModel.Name;
				student.Email = vewModel.Email;
				student.Phone = vewModel.Phone;
				student.Subscribed = vewModel.Subscribed;

				await dBContext.SaveChangesAsync();
			}

			return RedirectToAction("List", "Student");

		}
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var student = await dBContext.Students.FindAsync(id);
			if (student != null)
			{
				dBContext.Students.Remove(student);
				await dBContext.SaveChangesAsync();
			}
			return RedirectToAction("List", "Student");
		}
	}
}
