using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
{
    public class ResponseController : Controller
    {
        private readonly IResponseRepository responseRepository;

        public ResponseController(IResponseRepository responseRepository)
        {
            this.responseRepository = responseRepository;
        }


        // GET: ResponseController
        public ActionResult Index()
        {
            var response = this.responseRepository.GetAll();
            return View(response);
        }

        // GET: ResponseController/Details/5
        public ActionResult Details(int id)
        {
            var response = this.responseRepository.GetById(id);
            return View(response);
        }

        // GET: ResponseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResponseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Response response)
        {
            try
            {
                this.responseRepository.Add(response);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResponseController/Edit/5
        public ActionResult Edit(int id)
        {
            var response = this.responseRepository.GetById(id);
            return View(response);
        }

        // POST: ResponseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Response response)
        {
            try
            {
                this.responseRepository.Modify(response);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResponseController/Delete/5
        public ActionResult Delete(int id)
        {
            var response = this.responseRepository.GetById(id);
            return View(response);
        }

        // POST: ResponseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                this.responseRepository.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
