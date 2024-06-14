using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;
using System.Drawing;

namespace API_FashionShop.Services
{
    public class PaymentService
    {
        public byte[] Genarate(string amount, string info)
        {
            var apiRequest = new ApiRequest();
            apiRequest.acqId = 970407;
            apiRequest.accountNo = 6616092002;
            apiRequest.accountName = "Nguyen Tuan Bao";
            apiRequest.amount = Convert.ToInt32(amount);
            apiRequest.addInfo = info;
            apiRequest.format = "text";
            apiRequest.template = "compact";
            //chuyển đổi chuỗi json
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            // sử dụng thư viện restsharp để gửi yêu cầu Post tới API.
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = RestSharp.Method.Post;
            request.AddHeader("Accept", "application/json");
            //gửi chuỗi JSON đã được tạo ra như là phần thân của yêu cầu
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            //thưc thi API
            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content!);


            var imageData = dataResult!.data.qrDataURL.Replace("data:image/png;base64,", "");
            byte[] imageBytes = Convert.FromBase64String(imageData);
            string imagePath = "Images/qr.png";
            System.IO.File.WriteAllBytes(imagePath, imageBytes);
            var file = System.IO.File.ReadAllBytes(imagePath);
            System.IO.File.Delete(imagePath);
            return file;

        }
        public class ApiRequest
        {
            public long accountNo { get; set; }
            public string accountName { get; set; }
            public int acqId { get; set; }
            public int amount { get; set; }
            public string addInfo { get; set; }
            public string format { get; set; }
            public string template { get; set; }
        }

        public class Data
        {
            public int acpId { get; set; }
            public string accountName { get; set; }
            public string qrCode { get; set; }
            public string qrDataURL { get; set; }
        }

        public class ApiResponse
        {
            public string code { get; set; }
            public string desc { get; set; }
            public Data data { get; set; }
        }
    }
}
