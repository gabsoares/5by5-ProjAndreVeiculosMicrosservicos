using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pix
    {
        public static readonly string GETALL = "SELECT [p].[Id] AS PixId, [p].[PixKey], [p].[PixTypeId], [p0].[Id] AS PixTypeId, [p0].[Description] FROM [Pix] AS [p] LEFT JOIN [PixType] AS [p0] ON [p].[PixTypeId] = [p0].[Id]";
        public static readonly string GETALLDapper = "SELECT [p].[Id], [p].[PixKey], [p].[PixTypeId], [p0].[Id] AS Id, [p0].[Description] FROM [Pix] AS [p] LEFT JOIN [PixType] AS [p0] ON [p].[PixTypeId] = [p0].[Id]";

        public int Id { get; set; }
        public PixType? PixType { get; set; }
        public string PixKey { get; set; }

        public Pix()
        {
            
        }

        public Pix(PixDTO pixDTO)
        {
            PixType pixType = new() { Id = pixDTO.PixTypeId };
            this.PixType = pixType;
            this.PixKey = pixDTO.PixKey;
        }
    }
}