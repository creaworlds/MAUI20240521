using System;
using System.Threading.Tasks;
using TechnicalAxosModels.Countries;
using TechnicalAxosModels.Responses;

namespace TechnicalAxosServices
{
    public static partial class Country
    {
        public static async Task<ResponseObject<CountryData[]>> List()
        {
            var response = new ResponseObject<CountryData[]>();

            using (var client = ApiHandler.Create())
            {
                try
                {
                    var url = "https://restcountries.com/v3.1/all";
                    var json = await client.GetStringAsync(url);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    response.Result = Newtonsoft.Json.JsonConvert.DeserializeObject<CountryData[]>(json);
                    response.Success = true;
                }
                catch (System.Exception ex)
                {
                    response.Message = ex.Message;
                }
            }

            return response;
        }
    }
}