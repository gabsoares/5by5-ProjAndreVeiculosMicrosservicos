using Models;
using Models.DTO;
using Newtonsoft.Json;
using NuGet.Protocol;
using Repositories.Repositories;

namespace Services.Services;

public class FinancingService
{
    private readonly FinancingRepository _financingRepository;
    private HttpClient _http;

    public FinancingService()
    {
        _financingRepository = new FinancingRepository();
        _http = new HttpClient();
    }

    public async Task<List<Financing>> GetAllFinancing()
    {
        var populateFinancingList = new List<Financing>();
        var financingList = await _financingRepository.GetAllFinancing();
        foreach (var dto in financingList)
        {
            var saleResponse = await _http.GetAsync($"https://localhost:7239/api/Sales/{dto.SaleId}");
            var bankResponse = await _http.GetAsync($"https://localhost:7040/api/Banks/{dto.BankId}");
            var sale = JsonConvert.DeserializeObject<Sale>(await saleResponse.Content.ReadAsStringAsync());
            var bank = JsonConvert.DeserializeObject<Bank>(await bankResponse.Content.ReadAsStringAsync());

            populateFinancingList.Add(new Financing()
            {
                Id = dto.Id,
                Bank = bank,
                Sale = sale,
                FinancingDate = dto.FinancingDate
            });
        }

        return populateFinancingList;
    }

    public async Task<Financing?> GetFinancingById(int id)
    {
        var populateFinancing = new Financing();
        var financingDto = await _financingRepository.GetFinancingById(id);

        if (financingDto == null)
        {
            return null;
        }

        var saleResponse = await _http.GetAsync($"https://localhost:7239/api/Sales/{financingDto.SaleId}");
        var bankResponse = await _http.GetAsync($"https://localhost:7040/api/Banks/{financingDto.BankId}");
        var sale = JsonConvert.DeserializeObject<Sale>(await saleResponse.Content.ReadAsStringAsync());
        var bank = JsonConvert.DeserializeObject<Bank>(await bankResponse.Content.ReadAsStringAsync());

        populateFinancing = new Financing()
        {
            Id = financingDto.Id,
            Bank = bank,
            Sale = sale,
            FinancingDate = financingDto.FinancingDate
        };

        return populateFinancing;
    }

    public async Task<int> InsertFinancing(FinancingDTO financingDto)
    {
        var saleResponse = await _http.GetAsync($"https://localhost:7239/api/Sales/{financingDto.SaleId}");
        var bankResponse = await _http.GetAsync($"https://localhost:7040/api/Banks/{financingDto.BankId}");
        var sale = JsonConvert.DeserializeObject<Sale>(await saleResponse.Content.ReadAsStringAsync());
        var bank = JsonConvert.DeserializeObject<Bank>(await bankResponse.Content.ReadAsStringAsync());

        var populateFinancing = new Financing()
        {
            Id = financingDto.Id,
            Bank = bank,
            Sale = sale,
            FinancingDate = financingDto.FinancingDate
        };
        
        return await _financingRepository.InsertFinancing(populateFinancing);
    }
}