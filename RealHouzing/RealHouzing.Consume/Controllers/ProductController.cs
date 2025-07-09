using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealHouzing.Consume.Models;
using System.Text;

namespace RealHouzing.Consume.Controllers;

public class ProductController : Controller
{
    //Http istekleri oluşturmamızı sağlayan interface 
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {

        var client = _httpClientFactory.CreateClient();
        //Async method çağırırken 'await' keyini unutma!!
        var responseMessage = await client.GetAsync("http://localhost:7073/api/Product");
        if (responseMessage.IsSuccessStatusCode)
        {
            //Gelen datayı string'e dönüştürdük
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ProductListViewModel>>(jsondata);
            return View(values);
        }
        return View();
    }

    public async Task<IActionResult> DeleteProduct(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"http://localhost:7073/api/Product?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> AddProduct()
    {
        #region İlişkili tablodaki category bilgilerini dropdown'a atama
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7073/api/Category");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<CategoryListViewModel>>(jsonData);
        List<SelectListItem> values2 = (from x in values
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.CategoryID.ToString()
                                        }).ToList();
        ViewBag.Categories = values2;
        return View();

        #endregion
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductViewModel addProductViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(addProductViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:7073/api/Product", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        #region İlişkili kategori verilerini getiriyoruz
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7073/api/Category");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<CategoryListViewModel>>(jsonData);
        List<SelectListItem> items = (from x in values
                                      select new SelectListItem
                                      {
                                          Text = x.CategoryName,
                                          Value = x.CategoryID.ToString()
                                      }).ToList();
        ViewBag.Categories = items;
        #endregion
        var _client = _httpClientFactory.CreateClient();
        var _responseMessage = await _client.GetAsync($"http://localhost:7073/api/Product/GetProductById?id={id}");
        if (_responseMessage.IsSuccessStatusCode)
        {
            var _jsonData = await _responseMessage.Content.ReadAsStringAsync();
            var _values = JsonConvert.DeserializeObject<UpdateProductViewModel>(_jsonData);
            return View(_values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductViewModel updateProductViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateProductViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("http://localhost:7073/api/Product/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
