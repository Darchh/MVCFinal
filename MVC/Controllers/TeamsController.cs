using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;
using BLL.DAL;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Authorization;

// Generated from Custom Template.

namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeamsController : MvcController
    {
        // Service injections:
        private readonly IService<Team, TeamModel> _teamService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public TeamsController(
            IService<Team, TeamModel> teamService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _teamService = teamService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Teams
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _teamService.Query().ToList();
            return View(list);
        }

        // GET: Teams/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _teamService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamModel team)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _teamService.Create(team.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = team.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(team);
        }

        // GET: Teams/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _teamService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Teams/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeamModel team)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _teamService.Update(team.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = team.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(team);
        }

        // GET: Teams/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _teamService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Teams/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _teamService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
