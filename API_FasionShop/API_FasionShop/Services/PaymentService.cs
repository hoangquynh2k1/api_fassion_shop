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
            //"accountNo": 113366668888,
            //"accountName": "QUY VAC XIN PHONG CHONG COVID",
            //"acqId": 970415,
            //"amount": 79000,
            //"addInfo": "Ung Ho Quy Vac Xin",
            //"format": "text",
            //"template": "compact"
            var apiRequest = new ApiRequest();
            apiRequest.acqId = 970407;
            apiRequest.accountNo = 6616092002;
            apiRequest.accountName = "Nguyen Tuan Bao";
            apiRequest.amount = Convert.ToInt32(amount);
            apiRequest.addInfo = info;
            apiRequest.format = "text";
            apiRequest.template = "compact";
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            // use restsharp for request api.
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = RestSharp.Method.Post;
            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

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
