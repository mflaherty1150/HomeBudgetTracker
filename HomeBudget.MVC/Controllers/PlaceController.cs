using HomeBudget.Contracts;
using HomeBudget.Models.Place;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.MVC.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        // GET: PlaceController
        public async Task<IActionResult> Index()
        {
            var places = await _placeService.GetAllPlacesAsync();
            return View(places);
        }

        // GET: PlaceController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: PlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlaceCreate placeCreate)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrMsg"] = "Model State is Invalid";
                return View(placeCreate);
            }
            else
            {
                if (await _placeService.CreatePlaceAsync(placeCreate))
                    return RedirectToAction("Index");
            }
            TempData["ErrMsg"] = "Unable to Create the Place. Please try again later.";
            return View(placeCreate);
        }

        // GET: PlaceController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var place = await _placeService.GetPlaceByIdAsync((int)id);
            if (place == null) return NotFound();

            return View(place);
        }

        // GET: PlaceController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var place = await _placeService.GetPlaceByIdAsync((int)id);
            if (place is null) return NotFound();


            return View(place);
        }

        // POST: PlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlaceEdit model)
        {
            if (!ModelState.IsValid || model is null)
            {
                TempData["ErrMsg"] = "Model State is Invalid";
                return View(model);
            }
            if (id != model.Id)
            {
                TempData["ErrMsg"] = "Model Id mismatch";
                return View(model);
            }

            if (await _placeService.UpdatePlaceAsync(model))
                return RedirectToAction(nameof(Index));

            TempData["ErrMsg"] = "Unable to update Model to the Database";
            return UnprocessableEntity();
        }

        // GET: PlaceController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var place = await _placeService.GetPlaceByIdAsync((int)id);
            if (place == null) return NotFound();

            return View(place);
        }

        // POST: PlaceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return NotFound();

            if (await _placeService.DeletePlaceAsync((int)id))
                return RedirectToAction(nameof(Index));
            return UnprocessableEntity(id);
        }
    }
}
