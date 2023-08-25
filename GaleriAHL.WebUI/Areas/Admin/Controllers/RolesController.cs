using GaleriAHL.Business.Abstract;
using GaleriAHL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GaleriAHL.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class RolesController : Controller
    {//Business ISERVICE
        private readonly IService<Rol> _service;

        public RolesController(IService<Rol> service)//Dependency Injection
        {
            _service = service;
        }

        // GET: RolesController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync(); //_service listeyi çektik
            return View(model);//model'i view içerisine gönderdik.
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rol rol)
        {
            try
            {
                _service.Add(rol);//rol eklenmek üzerine işaretlenir
                _service.Save();//rol kaydedilir.
                return RedirectToAction(nameof(Index));//fiziksel olarak Async olmadığı için IndexAsync yerine Index kullandım
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {//edit sayfasının çalışması için veri yollarız.
            var model = await _service.FindAsync(id); //veriyi getirir.
            return View(model);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Rol rol)
        {
            try
            {
                _service.Update(rol);//gelen veri update edilir ve save ile güncelleme kaydedilir.
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id); //veriyi getirir.
            return View(model);
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rol rol)
        {
            try
            {
                _service.Delete(rol);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
