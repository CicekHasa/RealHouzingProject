using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealHouzing.Consume.Models;
using System.Text;

namespace RealHouzing.Consume.Controllers;

public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        //İlk olarak Http istekleri yapmak için HttpClient nesnesi oluşturuyoruz.
        var client =_httpClientFactory.CreateClient();
        //GetAsync veriyi çekmek için kullanılan bir methoddur.
        //Parametre içinde hangi apiye istek atacaksak onun url'ini girmek gerekiyor. Swaggerdan bakılabilir.
        var responseMessage = await client.GetAsync("http://localhost:47572/api/Category");
        //Response başarılı dönerse
        if (responseMessage.IsSuccessStatusCode)
        {
            //Gelen response mesajını içeriğini asenkron method ile stringe çeviriyoruz.
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            //json formatta dönüştürdüğüm string veriyi benim listede vereceğim sınıfa dönüştürecek.
            var values = JsonConvert.DeserializeObject<List<CategoryListViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public IActionResult AddCategory()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddCategory(AddCategoryViewModel addCategoryViewModel)
    {
        //Http istekleri oluşturmak için HttpClient nesnesi oluşturduk.
        var client = _httpClientFactory.CreateClient();
        //addCategoryViewModel'i json formatına dönüştürür.
        var jsonData = JsonConvert.SerializeObject(addCategoryViewModel);
        //HTTP isteğinin body’sine JSON verisini eklemek için bir içerik nesnesi oluşturur.
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //client'a post işlemi yaparak hangi adresi kullanıcağını ve göndereceğin içeriği parametre olarak gönder.
        var responseMessage = await client.PostAsync("http://localhost:47572/api/Category", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        var client=_httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"http://localhost:47572/api/Category?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:47572/api/Category/GetCategory?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            //Gelen jsonDatayı string yapıya dönüştür.
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<UpdateCategoryViewModel>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
    {
        var client=_httpClientFactory.CreateClient();
        var jsonData=JsonConvert.SerializeObject(updateCategoryViewModel);
        StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
        var responseMessage = await client.PutAsync("http://localhost:47572/api/Category/",stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
