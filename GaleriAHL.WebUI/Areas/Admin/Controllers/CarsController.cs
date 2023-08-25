using GaleriAHL.Business.Abstract;
using GaleriAHL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GaleriAHL.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class CarsController : Controller
    {
        private readonly IService<Arac> _service;
        private readonly IService<Marka> _serviceMarka;

        public CarsController(IService<Arac> service, IService<Marka> serviceMarka)
        {
            _service = service;
            _serviceMarka = serviceMarka;
        }

        // GET: CarsController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync(); //_service listeyi çektik
            return View(model);//model'i view içerisine gönderdik.
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(),"Id","Ad");
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Arac arac)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(arac);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(),"Id","Ad");
            return View(arac);
        }

        // GET: CarsController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Ad");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Arac arac)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(arac);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Ad");
            return View(arac);
        }

        // GET: CarsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Arac arac)
        {
                try
                {
                    _service.Delete(arac);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
        }
    }
}
