using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Controllers
{
    public class BillingController : Controller
    {
        public Commonview obj;
        public Repo obj1;
        public dropdownrepo obj2;
        public BillingController()
        {
            obj = new Commonview();
            obj1 = new Repo();
            obj2 = new dropdownrepo();
        }
        public ActionResult Index()
        {

            var model = new Commonview();
            model.BillingCreate = new BillingAddressess();
            model.ShippingCreate = new ShippingAddress();
            model.AddProduct = new AddProduct();
            model.Cart = new List<AddProduct>();
            model.Cart = obj1.ListProduct();
            model.Type = obj2.ListProduct();
           

            return View("Mainview", model);
        }
        public ActionResult Totalamount()
        {
            var total = new Commonview();
            total.Total = new List<Total>();
            total.Total = obj1.Totalamount();
            return View("Mainview", total);

        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Commonview data)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Mainview", data);

                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Insert(AddProduct data)
        {
            try
            {
                ModelState.Remove("Code");
                ModelState.Remove("Quantity");
                ModelState.Remove("ProductName");
                if (ModelState.IsValid)
                {
                    obj1.InsertProduct(data);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Mainview", data);

                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BillingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BillingController/Delete/5
        public ActionResult Delete(int No)
        {
            var result = obj1.Getproduct(No);
            return View("Delete", result);
        }

        // POST: BillingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int No)
        {
            try
            {
                obj1.Delete(No);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
