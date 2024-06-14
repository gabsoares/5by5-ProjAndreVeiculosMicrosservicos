using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using Models.DTO;
using ZstdSharp.Unsafe;

namespace Repositories.Repositories;

public class FinancingRepository
{
    private readonly SqlConnection _connection;

    public FinancingRepository()
    {
        _connection = new SqlConnection
        {
            ConnectionString = "Data Source = 127.0.0.1; " +
                               "Initial Catalog=DBProjAndreMicrosservicos; " +
                               "User Id=sa; " +
                               "Password=SqlServer2019!; " +
                               "TrustServerCertificate=True;"
        };
    }

    public async Task<List<FinancingDTO>> GetAllFinancing()
    {
        List<FinancingDTO> financing = new();
        try
        {
            _connection.Open();
            var query = await _connection.QueryAsync<FinancingDTO>(Financing.GETALL);
            foreach (var item in query)
            {
                financing.Add(item);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            _connection.Close();
        }

        return financing;
    }

    public async Task<FinancingDTO?> GetFinancingById(int id)
    {
        FinancingDTO? financing = null;
        try
        {
            _connection.Open();
            financing = await _connection.QueryFirstOrDefaultAsync<FinancingDTO>(Financing.GETALL, new { Id = id });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            _connection.Close();
        }

        return financing;
    }

    public async Task<int> InsertFinancing(Financing financing)
    {
        int financingId;
        try
        {
            _connection.Open();
            financingId = await _connection.ExecuteScalarAsync<int>(Financing.INSETONE, new
            {
                saleId = financing.Sale.Id,
                financingDate = financing.FinancingDate,
                bankCNPJ = financing.Bank.CNPJ
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            _connection.Close();
        }

        return financingId;
    }
}