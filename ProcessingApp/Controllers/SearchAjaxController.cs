using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProcessingApp.Data;
using ProcessingApp.Models;

namespace ProcessingApp.Controllers
{
    public class SearchAjaxController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchAjaxController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Index(string query)
        {
            ApplicationDbContext db = new ApplicationDbContext();
          
            var property = GetProperties(query);
            ViewBag.result = property;
            return PartialView(property);
        }

        public JsonResult autocomplete(string term)
        {
            var properties = GetProperties(term);
            String[] Results = properties.Select(property => property.PropertyName).ToArray();
            return new JsonResult(Results);
        }

        private List<PropertyModel> GetProperties(string query)
        {
            return _context
                .PropertyModel
                .Where(property => property.City
                            .ToLower()
                            .Contains(query.ToLower()))
                .ToList();
        }
    }
}