using asp_net_parcijalni_ispit_Ivan_Blazun.Data;
using asp_net_parcijalni_ispit_Ivan_Blazun.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Controllers
{
	public class TaskItemsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<AspNetUser> _userManager;

		public TaskItemsController(ApplicationDbContext context, UserManager<AspNetUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: TaskItems
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			return _context.TaskItems != null
				? View(await _context.TaskItems.Where(t => t.UserId == user.Id).ToListAsync())
				: Problem("Entity set 'ApplicationDbContext.TaskItems'  is null.");
		}

		// GET: TaskItems/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.TaskItems == null)
			{
				return NotFound();
			}

			var taskItem = await _context.TaskItems
				.FirstOrDefaultAsync(m => m.Id == id);
			if (taskItem == null)
			{
				return NotFound();
			}

			return View(taskItem);
		}

		// GET: TaskItems/Create
		public IActionResult Create()
		{
			var model = new TaskItem();
			return View(model);
		}

		// POST: TaskItems/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,TaskName,Description,Created, UserId")] TaskItem taskItem)
		{
			var user = await _userManager.GetUserAsync(User);

			if (ModelState.IsValid)
			{
				if (user.TodoList == null)
				{
					user.TodoList = new TodoList();
					_context.TodoLists.Add(user.TodoList);
				}
				user.TodoList.TaskItems.Add(taskItem);
				user.TodoList.UserId = taskItem.UserId!;
				user.TaskItem.Add(taskItem);

				_context.Entry(user).State = EntityState.Modified;

				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(taskItem);
		}

		// GET: TaskItems/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.TaskItems == null)
			{
				return NotFound();
			}

			var taskItem = await _context.TaskItems.FindAsync(id);
			if (taskItem == null)
			{
				return NotFound();
			}

			return View(taskItem);
		}

		// POST: TaskItems/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id,
			[Bind("Id,TaskName,Description,IsCompleted,Created,UserId")] TaskItem taskItem)
		{
			if (id != taskItem.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(taskItem);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TaskItemExists(taskItem.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}

				return RedirectToAction(nameof(Index));
			}

			return View(taskItem);
		}

		// GET: TaskItems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.TaskItems == null)
			{
				return NotFound();
			}

			var taskItem = await _context.TaskItems
				.FirstOrDefaultAsync(m => m.Id == id);
			if (taskItem == null)
			{
				return NotFound();
			}

			return View(taskItem);
		}

		// POST: TaskItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.TaskItems == null)
			{
				return Problem("Entity set 'ApplicationDbContext.TaskItems'  is null.");
			}

			var taskItem = await _context.TaskItems.FindAsync(id);
			if (taskItem != null)
			{
				_context.TaskItems.Remove(taskItem);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TaskItemExists(int id)
		{
			return (_context.TaskItems?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateTaskStatus(int id)
		{
			var task = await _context.TaskItems.FindAsync(id);
			if (task != null)
			{
				_context.Remove(task);
				await _context.SaveChangesAsync();

				return RedirectToAction("Index", "TaskItems");
			}

			return RedirectToAction("Index", "TaskItems");
		}


	}
}