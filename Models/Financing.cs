using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Financing
{
    public static readonly string GETALL = " select Id, SaleId, FinancingDate, BankCNPJ from Financing ";
    public static readonly string GETONE = " select Id, SaleId, FinancingDate, BankCNPJ from Financing where Id = @Id ";

    public static readonly string INSETONE =
        " insert into Financing (SaleId, FinancingDate, BankCNPJ) values (@saleId, @financingDate, @bankCNPJ); SELECT CAST(scope_identity() AS int)";

    public int Id { get; set; }
    public Sale Sale { get; set; }
    public DateTime FinancingDate { get; set; }
    public Bank Bank { get; set; }
}