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
        public IActionResult Index(string term)
        {
            var property = GetProperties(term);
            return PartialView(property);
        }
        public JsonResult autocomplete(string term)
        {
            var properties = GetProperties(term);
            String[] Results = properties.Select(prop => prop.City).ToArray();
            return new JsonResult(Results); 
        }

        private List<PropertyModel> GetProperties(string term)
        {
            
            return _context
                .PropertyModel
                .Where(property => property.City
                            .ToLower()
                            .Contains(term.ToLower()))
                .ToList();
        }
    }
}