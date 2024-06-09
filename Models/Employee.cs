using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Person
    {
        public readonly static string GETALL = "SELECT [e].[CPF], [e].[AdressId], [e].[Comission], [e].[ComissionValue], [e].[DateOfBirth], [e].[Email], [e].[Name], [e].[Phone], [e].[RoleId] AS RoleId, [r].[Id], [r].[Description], [a].[Id] AS AdressId, [a].[City], [a].[Complement], [a].[District], [a].[Number], [a].[PublicPlace], [a].[UF], [a].[ZipCode] FROM [Employee] AS [e] LEFT JOIN [Role] AS [r] ON [e].[RoleId] = [r].[Id] LEFT JOIN [Adress] AS [a] ON [e].[AdressId] = [a].[Id]";
        public readonly static string GETALLDapper = "SELECT [e].[CPF], [e].[AdressId], [e].[Comission], [e].[ComissionValue], [e].[DateOfBirth], [e].[Email], [e].[Name], [e].[Phone], [e].[RoleId] AS Id, [r].[Id], [r].[Description], [a].[Id] AS Id, [a].[City], [a].[Complement], [a].[District], [a].[Number], [a].[PublicPlace], [a].[UF], [a].[ZipCode] FROM [Employee] AS [e] LEFT JOIN [Role] AS [r] ON [e].[RoleId] = [r].[Id] LEFT JOIN [Adress] AS [a] ON [e].[AdressId] = [a].[Id]";
        public Role? Role { get; set; }
        public Decimal ComissionValue { get; set; }
        public Decimal Comission { get; set; }
    }
}