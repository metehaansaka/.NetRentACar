using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class ArabaController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public ArabaController(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            List<Araba> arabas = new List<Araba>();
            Marka marka = new Marka();
            Model model = new Model();
            List<ArabaDTO> arabaDTOs = new List<ArabaDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44377/api/Araba/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    arabas = JsonConvert.DeserializeObject<List<Araba>>(apiResponse);
                    foreach (var item in arabas)
                    {
                        var response2 = await httpClient.GetAsync("https://localhost:44377/api/Marka/get?id="+item.MarkaId);
                        apiResponse = await response2.Content.ReadAsStringAsync();
                        marka = JsonConvert.DeserializeObject<Marka>(apiResponse);
                        response2 = await httpClient.GetAsync("https://localhost:44377/api/Model/get?id=" + item.ModelId);
                        apiResponse = await response2.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<Model>(apiResponse);
                        var config = new MapperConfiguration(cfg => { cfg.CreateMap<Araba, ArabaDTO>(); });
                        IMapper mapper = config.CreateMapper();
                        var dest = mapper.Map<Araba, ArabaDTO>(item);
                        dest.Marka = marka.MarkaAdi;
                        dest.Model = model.ModelAdi;
                        //ArabaDTO arabaDTO = new ArabaDTO();
                        //arabaDTO.ArabaId = item.ArabaId;
                        //arabaDTO.Fiyat = item.Fiyat;
                        //arabaDTO.Marka = marka.MarkaAdi;
                        //arabaDTO.Model = model.ModelAdi;
                        //arabaDTO.Sanziman = item.Sanziman;
                        //arabaDTO.Vites = item.Vites;
                        //arabaDTO.Yakit = item.Yakit;
                        arabaDTOs.Add(dest);
                    }
                }
            }

            return View(arabaDTOs);
        }

        public async Task<IActionResult> Ekle()
        {
            List<Marka> markas;
            List<Model> models;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44377/api/Marka/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    markas = JsonConvert.DeserializeObject<List<Marka>>(apiResponse);
                    var test = new SelectList(markas, "MarkaId", "MarkaAdi");
                    ViewBag.dgr = test;
                }
                using (var response = await httpClient.GetAsync("https://localhost:44377/api/Model/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    models = JsonConvert.DeserializeObject<List<Model>>(apiResponse);
                    var test = new SelectList(models, "ModelId", "ModelAdi");
                    ViewBag.dgr2 = test;
                }
            }
            
            return View(Tuple.Create<Marka,Model>(new Marka(), new Model()));
        }

        [HttpPost]
        public IActionResult Ekle(Araba araba, IFormFile file)
        {
            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                araba.Resim = uniqueFileName;
            }
            string apiUrl = "https://localhost:44377/api/Araba";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                string data = JsonConvert.SerializeObject(araba);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/add", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            string apiUrl = "https://localhost:44377/api/Araba/delete?id="+id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);


            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Get(int id)
        {

            Araba araba = new Araba();
            using (var httpClient = new HttpClient())
            {
                List<Marka> markas;
                List<Model> models;
                using (var response = await httpClient.GetAsync("https://localhost:44377/api/Araba/get?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    araba = JsonConvert.DeserializeObject<Araba>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("https://localhost:44377/api/Marka/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    markas = JsonConvert.DeserializeObject<List<Marka>>(apiResponse);
                    var selectList = new SelectList(markas, "MarkaId", "MarkaAdi", araba.MarkaId);
                    ViewData["Marka"] = selectList;
                }
                using (var response = await httpClient.GetAsync("https://localhost:44377/api/Model/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    models = JsonConvert.DeserializeObject<List<Model>>(apiResponse);
                    var selectList = new SelectList(models, "ModelId", "ModelAdi", araba.ModelId);
                    ViewData["Model"] = selectList;
                }

            }
            return View("Guncelle",Tuple.Create<Araba,Marka, Model>(araba, new Marka(), new Model()));
        }

        public  IActionResult Guncelle(Araba araba, IFormFile file)
        {
            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                araba.Resim = uniqueFileName;
            }
            string apiUrl = "https://localhost:44377/api/Araba";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                string data = JsonConvert.SerializeObject(araba);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/update", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return Redirect("Index");
        }

        

    }
    
}
