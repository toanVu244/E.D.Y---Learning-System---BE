using E.D.Y_Serivce.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json.Nodes;

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaypalController : ControllerBase
    {
        public string PaypalClientId { get; set; } = "";
        public string PaypalSecret { get; set; } = "";
        public string PaypalUrl { get; set; } = "";
        private readonly IConfiguration _configuration;
        public PaypalController(IConfiguration configuration)
        {
            _configuration = configuration;
            PaypalClientId = _configuration["PayPal:ClientId"];
            PaypalSecret = _configuration["PayPal:Secret"];
            PaypalUrl = _configuration["PayPal:Url"];
        }
        [NonAction]
        public async Task<string> GetAccessTokenAsync()
        {

            string accessToken = "";

            string url = PaypalUrl + "/v1/oauth2/token";

            using (var client = new HttpClient())
            {
                string credentials64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(PaypalClientId + ":" + PaypalSecret));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + credentials64);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("grant_type=client_credentials", null, "application/x-www-form-urlencoded");

                var httpResponse = await client.SendAsync(requestMessage);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var strResponse = await httpResponse.Content.ReadAsStringAsync();

                    var jsonResponse = JsonNode.Parse(strResponse);
                    if (jsonResponse != null)
                    {
                        accessToken = jsonResponse["access_token"]?.ToString() ?? "";
                    }
                }
            }
            return accessToken;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] JsonObject data)
        {
            var totalAmount = data?["amount"]?.ToString();
            if (totalAmount == null)
            {
                return new JsonResult(new { orderID = "" });
            }

            JsonObject createOrderObj = new JsonObject();
            createOrderObj.Add("intent", "CAPTURE");

            JsonObject amount = new JsonObject();
            amount.Add("currency_code", "USD");
            amount.Add("value", totalAmount);  // Corrected key "value"

            JsonObject purchaseUnit = new JsonObject();
            purchaseUnit.Add("amount", amount);

            JsonArray purchaseUnits = new JsonArray();
            purchaseUnits.Add(purchaseUnit);

            createOrderObj.Add("purchase_units", purchaseUnits);  // Corrected key "purchase_units"

            string accessToken = await GetAccessTokenAsync();

            string url = PaypalUrl + "/v2/checkout/orders";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);  // Ensure space after "Bearer"

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent(createOrderObj.ToString(), null, "application/json");

                var httpResponse = await client.SendAsync(requestMessage);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var strRespone = await httpResponse.Content.ReadAsStringAsync();
                    var jsonRespone = JsonNode.Parse(strRespone);
                    if (jsonRespone != null)
                    {
                        string paypalOrderId = jsonRespone["id"]?.ToString();
                        return new JsonResult(new { orderID = paypalOrderId });
                    }
                }
                else
                {
                    var errorResponse = await httpResponse.Content.ReadAsStringAsync();
                    return BadRequest(new { error = errorResponse });
                }
            }

            return new JsonResult(new { orderID = "" });
        }


        [HttpPost]
        public async Task<JsonResult> CompleteOrder([FromBody]JsonObject data)
        {
            var orderId = data?["orderID"]?.ToString();
            if(orderId == null)
            {
                return new JsonResult("error");
            }
            string accessToken = await GetAccessTokenAsync();

            string url = PaypalUrl + "/v2/checkout/orders/" + orderId + "/capture";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("", null, "application/json");

                var httpResponse = await client.SendAsync(requestMessage);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var strRespone = await httpResponse.Content.ReadAsStringAsync();
                    var jsonRespone = JsonNode.Parse(strRespone);
                    if (jsonRespone != null)
                    {
                        string paypalOrderStatus = jsonRespone["status"]?.ToString() ?? "";
                        if (paypalOrderStatus == "COMPLETED")
                        {
                            return new JsonResult("Successs");
                        }
                    }
                }
                var errorContent = await httpResponse.Content.ReadAsStringAsync();
                return new JsonResult($"Error: {httpResponse.ReasonPhrase}, Content: {errorContent}");
            }
        }
    }
}
