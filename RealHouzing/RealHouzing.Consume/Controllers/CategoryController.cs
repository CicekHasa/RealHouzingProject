using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealHouzing.Consume.Models;

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
}
