using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Pharmacy.DB;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class SupplierController : BaseController
    {
        public ActionResult AllSuppliers()
        {
            return View();
        }

        public JsonResult GetSupplierList([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
            var supplierList = context.Suppliers.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description,
                isActive = x.isActive
            }).ToList();
            return this.Json(supplierList.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult AddSupplier()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(SupplierValidation item)
        {
            try
            {
            Supplier obj = new Supplier();

            obj.Name = item.Name;
            obj.Description = item.Description;
            obj.isActive = item.isActive;

            context.Suppliers.Add(obj);
            context.SaveChanges();

            ModelState.Clear();
            return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}