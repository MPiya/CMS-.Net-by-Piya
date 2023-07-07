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
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        //Get
    public IActionResult Create() { 
        
        return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            // addring summary
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot match tne name");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Create successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }


        }

        public IActionResult Edit(int? id)
        {

            if(id==null)
            {
                return NotFound();
            }

           
  
           // var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (categoryFromDbFirst ==null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }


        //Get
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            // addring summary
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot match tne name");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save ();
                TempData["success"] = "Category updated successfully";
               
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


            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
            [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }


                _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Delete updated successfully";
            return RedirectToAction("Index");
            


        }
        public IActionResult Index()
        { 

            
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }
        public IActionResult Dada()
        {
          
            return View();
        }
    }
}
