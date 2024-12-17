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
    public class MatchesController : MvcController
    {
        // Service injections:
        private readonly IService<Matches, MatchesModel> _matchesService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public MatchesController(
            IService<Matches, MatchesModel> matchesService

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _matchesService = matchesService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Matches
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _matchesService.Query().ToList();
            return View(list);
        }

        // GET: Matches/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _matchesService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Matches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MatchesModel matches)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _matchesService.Create(matches.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = matches.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(matches);
        }

        // GET: Matches/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _matchesService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Matches/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MatchesModel matches)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _matchesService.Update(matches.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = matches.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(matches);
        }

        // GET: Matches/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _matchesService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Matches/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _matchesService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
