using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository requestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }


        // GET: ResponseController
        public ActionResult Index()
        {
            var request = this.requestRepository.GetAll();
            return View(request);
        }

        // GET: ResponseController/Details/5
        public ActionResult Details(int id)
        {
            var request = this.requestRepository.GetById(id);
            return View(request);
        }

        // GET: ResponseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResponseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Request request)
        {
            try
            {
                this.requestRepository.Add(request);
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
            var request = this.requestRepository.GetById(id);
            return View(request);
        }

        // POST: ResponseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Request request)
        {
            try
            {
                this.requestRepository.Modify(request);
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
            var request = this.requestRepository.GetById(id);
            return View(request);
        }

        // POST: ResponseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                this.requestRepository.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
