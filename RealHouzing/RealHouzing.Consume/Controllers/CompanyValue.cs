using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealHouzing.Consume.Models;
using System.Text;

namespace RealHouzing.Consume.Controllers;

public class CompanyValue : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public CompanyValue(IHttpClientFactory httpClientFactory)
    {
            _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        //İlk olarak oluşturduğun interface den client oluşturmalısın.
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7073/api/CompanyValue");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CompanyValueListViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }

    public async Task<IActionResult> DeleteCompanyValue(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"http://localhost:7073/api/CompanyValue?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult AddCompanyValue()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCompanyValue(AddCompanyValueViewModel addCompanyValueViewModel)
    {
        var client=_httpClientFactory.CreateClient();
        var jsonData=JsonConvert.SerializeObject(addCompanyValueViewModel);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:7073/api/CompanyValue",content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCompanyValue(int id)
    {
        var client=_httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:7073/api/CompanyValue/GetCompanyValueById?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCompanyValueViewModel>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCompanyValue(UpdateCompanyValueViewModel updateCompanyValueViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateCompanyValueViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("http://localhost:7073/api/CompanyValue/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

}
