﻿using Pharmacy.DB;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class ItemTypeController : BaseController
    { // GET: Company
        public ActionResult AllTypes()
        {
            return View();
        }

        public JsonResult GetTypeList([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
            var itemTypes = context.ItemTypes.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description,
                isActive = x.isActive
            }).ToList();
            return this.Json(itemTypes.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult AddType()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddType(ItemTypeValidation item)
        {
            try{
            ItemType obj = new ItemType();

            obj.Name = item.Name;
            obj.Description = item.Description;
            obj.isActive = item.isActive;

            context.ItemTypes.Add(obj);
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