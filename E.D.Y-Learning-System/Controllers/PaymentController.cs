using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _PaymentService;
        private readonly IConfiguration _configuration;
        public string PayOSClientId { get; set; } = "";
        public string PayOSApikey { get; set; } = "";
        public PaymentController(IPaymentService paymentService, IConfiguration configuration)
        {
            _PaymentService = paymentService;
            _configuration = configuration;
            PayOSClientId = _configuration["payOS:clientId"];
            PayOSApikey = _configuration["payOS:apiKey"];

        }

        [HttpGet("all-Payment")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _PaymentService.GetAllPaymentAsync();
            if (payments == null)
            {
                return NotFound();
            }
            return Ok(payments);
        }

        [HttpGet("all-Payment-byUID")]
        public async Task<IActionResult> GetAllPaymentsByUID(string uid)
        {
            var payments = await _PaymentService.GetAllPaymentByUIDAsync(uid);
            if (payments == null)
            {
                return NotFound();
            }
            return Ok(payments);
        }

        [HttpPut("update-payment-status")]
        public async Task<IActionResult> UpdatePaymentStatus()
        {
            var payments = await _PaymentService.GetAllPaymentAsync();
            if (payments == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-client-id", PayOSClientId);
                client.DefaultRequestHeaders.Add("x-api-key", PayOSApikey);

                foreach (var item in payments)
                {
                    if (item.Status == 0)
                    {
                        var url = $"https://api-merchant.payos.vn/v2/payment-requests/{item.BankCode}";
                        try
                        {
                            var response = await client.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var responseData = await response.Content.ReadAsStringAsync();
                                var responseJson = JsonConvert.DeserializeObject<JObject>(responseData);

                                var statusFromAPI = responseJson["data"]?["status"]?.ToString() ?? "Unknown";
                                var description = responseJson["data"]?["transactions"]?.FirstOrDefault()?["description"]?.ToString() ?? "No description";

                                item.Status = MapStatusToInt(statusFromAPI);
                                item.PaymentInfo = description;

                                await _PaymentService.UpdatePaymentAsync(item);
                            }
                            else
                            {
                                item.Status = -1;
                                item.PaymentInfo = response.ReasonPhrase;
                            }
                        }
                        catch (Exception ex)
                        {
                            item.Status = -2;
                            item.PaymentInfo = ex.Message;
                        }

                        await Task.Delay(2000);
                    }
                }
            }

            return Ok("Payment statuses updated successfully.");
        }

        private int MapStatusToInt(string status)
        {
            return status switch
            {
                "PENDING" => 1,
                "PAID" => 2,
                "CANCELLED" => 3,
                _ => 0
            };
        }

        // GET api/<PaymentController>
        [HttpGet("get-Payment-by-id")]
        public async Task<IActionResult> GetPaymentByID(int id)
        {
            try
            {
                var users = await _PaymentService.GetPaymentByIdAsync(id);
                if (users == null)
                    return NotFound();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PaymentController>
        [HttpPost("add-Payment")]
        public async Task<IActionResult> AddPayment(PaymentViewModel Payment)
        {
            try
            {
                var result = await _PaymentService.CreatePaymentAsync(Payment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("detail-payment")]
        public async Task<string> GetPayOSRequestInfoAsync(string orderCode)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-client-id", PayOSClientId);
                client.DefaultRequestHeaders.Add("x-api-key", PayOSApikey);
                var url = $"https://api-merchant.payos.vn/v2/payment-requests/{orderCode}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
                else
                {
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
        }

        // PUT api/<PaymentController>
        [HttpPut("update-Payment")]
        public async Task<IActionResult> UpdatePayment(PaymentViewModel Payment)
        {
            try
            {
                var result = await _PaymentService.UpdatePaymentAsync(Payment);
                if (result != true)
                {
                    return NotFound();
                }
                return Ok("Update Payment Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PaymentController>
        [HttpDelete("delete-Payment")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                var result = await _PaymentService.DeletePaymentAsync(id);
                return Ok("Delete Payment Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
