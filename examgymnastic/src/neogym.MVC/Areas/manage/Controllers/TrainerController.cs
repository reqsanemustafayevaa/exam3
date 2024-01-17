using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using neogym.business.Exceptions;
using neogym.business.Servicecs;
using neogym.core.Models;

namespace neogym.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        public async Task<IActionResult> Index()
        {
            var trainers = await _trainerService.GetAllAsync();
            return View(trainers);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _trainerService.CreateAsync(trainer);
            }
            catch(InvalidImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var existtrainer = await _trainerService.GetByIdAsync(id);
            if(existtrainer == null)
            {
                throw new NullReferenceException();
            }
            return View(existtrainer);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Trainer trainer)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _trainerService.CreateAsync(trainer);
            }
            catch (InvalidImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
            return RedirectToAction("index");
            
           
        }
        public async Task<IActionResult> Delete(int id)
        {
            var existtrainer = await _trainerService.GetByIdAsync(id);
            if (existtrainer == null)
            {
                throw new NullReferenceException();
            }
            return View(existtrainer);


        }
        [HttpPost]
        public async Task<IActionResult> Delete(Trainer trainer)
        {
            var existtrainer = await _trainerService.GetByIdAsync();
            try
            {
                await _trainerService.DeleteAsync();
            }
            catch(NullReferenceException ex)
            {

            }
            return RedirectToAction("index");
        }
        
        


    }
}
