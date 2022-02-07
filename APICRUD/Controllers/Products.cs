using APICRUD.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APICRUD.Controllers
{
      
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        DataBaseContext _context;


        public Products(DataBaseContext context)
        {
            _context = context;

        }
       

        [HttpPost]
        public JsonResult Index(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                 
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()));

                    var objfiles = new Touches()
                    {
                        Id = 0,
                        description = newFileName,
                        
                        ListTypeId = 15,
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.pic = target.ToArray();
                    }
                  
                        _context.touches.Add(objfiles);
                        _context.SaveChanges();

                   

                }
            }
            return new JsonResult("Added Sucessfully");
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
           var produ = await _context.touches.ToListAsync();
           return new JsonResult(produ); 
        }
       
        
    }
}

