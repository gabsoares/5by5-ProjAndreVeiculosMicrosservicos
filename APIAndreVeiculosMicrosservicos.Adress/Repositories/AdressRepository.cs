using Microsoft.Data.SqlClient;
using Models.DTO;
using MongoDB.Driver;
using static Dapper.SqlMapper;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace APIAndreVeiculosMicrosservicos.Adress.Repositories
{
    public class AdressRepository
    {
        private string Conn { get; set; }
        private readonly string ConnMongo;
        private readonly IMongoCollection<Models.Adress> _adresses;
        public AdressRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
            ConnMongo = "mongodb://root:Mongo%402024%23@localhost:27017/";
            var client = new MongoClient(ConnMongo);
            var database = client.GetDatabase("DBProjAddress");
            _adresses = database.GetCollection<Models.Adress>("Address");
        }
        public async Task<List<Models.Adress>> GetAllAdresses(byte type)
        {
            List<Models.Adress> adresses = new();
            AdressDTO a = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Models.Adress.GETALL, db);
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                adresses.Add(new Models.Adress
                                {
                                    Id = (int)reader["Id"],
                                    PublicPlace = reader["PublicPlace"].ToString(),
                                    ZipCode = reader["ZipCode"].ToString(),
                                    District = reader["District"].ToString(),
                                    Complement = reader["Complement"].ToString(),
                                    Number = (int)reader["Number"],
                                    UF = reader["UF"].ToString(),
                                    City = reader["City"].ToString(),
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query(Models.Adress.GETALL);
                    foreach (var adress in query)
                    {
                        adresses.Add(new Models.Adress
                        {
                            Id = adress.Id,
                            PublicPlace = adress.PublicPlace,
                            ZipCode = adress.ZipCode,
                            District = adress.District,
                            Complement = adress.Complement,
                            Number = adress.Number,
                            UF = adress.UF,
                            City = adress.City,
                        });
                    }
                }
                db.Close();
            }
            return adresses;
        }

        public Models.Adress InsertOne(Models.Adress adress)
        {
            _adresses.InsertOne(adress);
            return adress;
        }
    }
}