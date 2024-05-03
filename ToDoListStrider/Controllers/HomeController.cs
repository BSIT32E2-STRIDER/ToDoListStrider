using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoListStrider.Application;
using ToDoListStrider.Models;

namespace ToDoListStrider.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoService _toDoService;

        public HomeController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            var pendingTasks = await _toDoService.GetPendingToDoItemsByUserId(userId);
            var completedTasks = await _toDoService.GetCompletedToDoItemsByUserId(userId);

            var viewModel = new DashboardViewModel
            {
                PendingToDoItems = pendingTasks,
                DoneToDoItems = completedTasks,
                Username = "User", // Replace with actual username retrieval logic
                PendingCount = pendingTasks.Count, // Update pending tasks count
                DoneCount = completedTasks.Count // Update completed tasks count
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_CompletedTasks", viewModel.DoneToDoItems);
            }

            return View(viewModel);
        }
    }
