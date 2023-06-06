using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
     

        public CompanyController(IUnitOfWork db)
        {
            _unitOfWork = db;

           
        }


        public IActionResult Index()
        {



            return View();
        }

        //Get

        public IActionResult Upsert(int? id)
        {

            Company company = new();
           

            if (id == null || id == 0)
            {
                //create product
                return View(company);
            }
            else
            {
                company = _unitOfWork. .GetFirstOrDefault(u => u.Id == id);
                //updae product

                return View(company);
            }


        }



 
   
  


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile file)
        {
           
          
            if (ModelState.IsValid)
            {

          


                // when Id is 0 it means new product is added, if itsn ot then user want to upddate the product
                if (obj.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                }
                _unitOfWork.Product.Add(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
               
                return RedirectToAction("Index");
            }

            return View(obj);

        }



     

     

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties:"Category,CoverType");
            return Json(new { data = productList });
        }

        //Post
        [HttpDelete]
	
		public IActionResult DeletePost(int? id)
		{

			var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

			if (obj == null)
			{
                return Json(new { success = false, message = "Error while deleting" });
			}

			var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.Trim('\\'));
			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}

			_unitOfWork.Product.Remove(obj);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete Successful" });
	


		}

		#endregion
	}
}
