using Microsoft.IdentityModel.Tokens;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using Repositories.Repositories;

namespace Services.Services;

public class FinancialPendingService
{
    private HttpClient _http = new()
    {
        BaseAddress = new Uri("https://localhost:7033/api/")
    };

    public async Task<FinancialPending?> PopulateDto(FinancialPendingDTO dto)
    {
        var response = await _http.GetAsync($"Customers/{dto.Cpf}");
        var json = await response.Content.ReadAsStringAsync();

        if (json.IsNullOrEmpty()) return null;

        var customer = JsonConvert.DeserializeObject<Customer>(json);

        return new FinancialPending
        {
            Id = dto.Id,
            BillingDate = dto.BillingDate,
            Customer = customer,
            Description = dto.Description,
            PendingDate = dto.PendingDate,
            Status = dto.Status,
            Value = dto.Value
        };
    }
}