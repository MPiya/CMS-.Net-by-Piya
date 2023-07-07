using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }


        public IActionResult Index()
        {


            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }


        //Get
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
   
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {

          

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "CovertYPE successfully";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if(id==null)
            {
                return NotFound();
            }

           
            var covertTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (covertTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(covertTypeFromDbFirst);
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {

          
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save ();
                TempData["success"] = "CoverType updated successfully";
               
                return RedirectToAction("Index");
            }

            return View(obj);

        }



        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }


            var CoverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id==id);

            if (CoverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDb);
        }

        [HttpPost,ActionName("Delete")]
            [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }


                _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Delete updated successfully";
            return RedirectToAction("Index");
            


        }
      
    }
}
