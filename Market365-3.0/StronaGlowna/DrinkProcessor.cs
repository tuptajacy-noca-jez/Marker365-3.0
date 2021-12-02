using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net;

namespace Market365_3._0.StronaGlowna
{
    public class DrinkProcessor
    {
        public static async Task<DrinkModel> LoadDrink()
        {
            string url = "https://www.thecocktaildb.com/api/json/v1/1/random.php";

            using (HttpResponseMessage response = await Helper.apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {

                    DrinkModelResult result = await response.Content.ReadAsAsync<DrinkModelResult>();

                    return result.Drinks[0];

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}