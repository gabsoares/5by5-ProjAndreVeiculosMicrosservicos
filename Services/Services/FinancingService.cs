using Models;
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
            var saleResponse = await _http.GetAsync($"https://localhost:7239/api/sale/{dto.SaleId}");
            var bankResponse = await _http.GetAsync($"https://localhost:7033/api/Bank/{dto.BankId}");
            var sale = JsonConvert.DeserializeObject<Sale>(saleResponse.Content.ToString());
            var bank = JsonConvert.DeserializeObject<Bank>(bankResponse.Content.ToString());

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

        var saleResponse = await _http.GetAsync($"https://localhost:7239/api/sale/{financingDto.SaleId}");
        var bankResponse = await _http.GetAsync($"https://localhost:7033/api/Bank/{financingDto.BankId}");
        var sale = JsonConvert.DeserializeObject<Sale>(saleResponse.Content.ToString());
        var bank = JsonConvert.DeserializeObject<Bank>(bankResponse.Content.ToString());

        populateFinancing = new Financing()
        {
            Id = financingDto.Id,
            Bank = bank,
            Sale = sale,
            FinancingDate = financingDto.FinancingDate
        };

        return populateFinancing;
    }

    public async Task<int> InsertFinancing(Financing financing)
    {
        return await _financingRepository.InsertFinancing(financing);
    }
}