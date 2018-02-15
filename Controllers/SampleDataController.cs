using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vue2Spa.Extensions;
using Vue2Spa.Models;

namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private MyDataContext db;

        public SampleDataController(MyDataContext context)
        {
            db = context;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<MyData> MyData([FromServices]ILoggerFactory loggerFactory)
        {
            var myData = db.MyDatas
                .Include(md => md.MyDataCategory)
                    .ThenInclude(mdc => mdc.Category)
                        ;

            var logger = loggerFactory.CreateLogger("FileLogger");
            logger.LogInformation($"{DateTime.Now.ToString()} Выдаем результаты MyDatas");

            return myData;
        }

        [HttpPost("[action]")]
        public IEnumerable<Category> GetCategories()
        {
            var categories = db.Categories;

            return categories;
        }

        [HttpPost("[action]")]
        public async Task<bool> AddMyData([FromBody]MyData myData)
        {
            if (ModelState.IsValid)
            {
                if (myData.Id > 0)
                {
                    var model = db.MyDatas
                        .Include(x => x.MyDataCategory)
                        .FirstOrDefault(x => x.Id == myData.Id);

                    db.TryUpdateManyToMany(model.MyDataCategory, myData.MyDataCategory
                    .Select(x => new MyDataCategory
                    {
                        CategoryId = x.CategoryId,
                        MyDataId = myData.Id
                    }), x => x.CategoryId);
                }
                else
                {
                    db.MyDatas.Add(myData);
                }
                await db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        [HttpPost("[action]")]
        public async Task<MyData> getSingleData([FromBody]Dictionary<string, int> id)
        {
            try
            {
                int _id = id["id"];
                var myData = await db.MyDatas.Include(x => x.MyDataCategory).SingleOrDefaultAsync(md => md.Id == _id);
                if (myData != null)
                {
                    return myData;
                }
                else
                {
                    throw new Exception("Id для редактирования не найден в БД!");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
        }

        [HttpPost("[action]")]
        public async Task<bool> DeleteMyData([FromBody]Dictionary<string, int> id)
        {
            try
            {
                int _id = id["id"];
                var myData = db.MyDatas.SingleOrDefault(md => md.Id == _id);
                if (myData != null)
                {
                    db.MyDatas.Remove(myData);
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("Id для удаления не найден в БД!");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
