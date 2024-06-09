namespace API_FashionShop.Entities
{
    public class MailContent
    {
        public string To { get; set; }              // Địa chỉ gửi đến
        public string Subject { get; set; }         // Chủ đề (tiêu đề email)
        public string Body { get; set; }            // Nội dung (hỗ trợ HTML) của email
    }
    public class MailHTML
    {
        public static string Header = "<!DOCTYPE html>" +
            "<html lang=\"en\">\r\n\r\n<head>" +
            "    <meta charset=\"UTF-8\">" +
            "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
            "    <title>Document</title>" +
            "    <!-- CSS only -->    <style>" +
            "        .cart-success__content { width: 100%; max-width: 800px; margin: 0 auto; padding: 50px 0; }" +
            "        .cart-success__header { margin-bottom: 25px; text-align: center; }" +
            "        .cart-success__title>h4 { margin: 0 0 25px; font-size: 28px; font-weight: 400; " +
            "            color: #f55334; }" +
            "        .cart-success__title>p, .cart-success__subtitle { margin: 0 0 10px; font-size: 12px; }" +
            "        .cart-success__body>p { font-size: 18px; margin-bottom: 12px; }" +
            "        .cart-success__body>table { font-size: 14px;        }" +
            "        .cart-success__body>table>thead>tr>th {font-size: 14px; font-weight: 100; }" +
            "        .cart-success__body>table>thead," +
            "        .cart-success__body>table>tbody>tr>td {" +
            "            text-align: center;        }" +
            "        .cart-success__item-title {" +
            "            text-align: left !important;        }" +
            "        .cart-success__addresss {" +
            "            font-size: 14px;" +
            "        }" +
            "        .cart-success__address-group {" +
            "            display: flex;" +
            "        }" +
            "        .cart-success__address-label {" +
            "            font-weight: 600;\r\n            margin-right: 6px;\r\n        }\r\n\r\n    </style>\r\n\r\n</head>\r\n\r\n" +
            "<body> " +
            "    <div class=\"container\">" +
            "        <div class=\"cart-success__content\">" +
            "            <div class=\"cart-success__header\">" +
            "                <div class=\"cart-success__title\">" +
            "                   <h4>Đặt hàng thành công!</h4>" +
            "                    <p>Cảm ơn bạn đã đặt mua hàng tại Male Fashion</p>" +
            "                    <p>Đơn hàng của bạn hiện đang được xử lý. Chúng tôi sẽ sớm liên hệ để giao hàng.</p>" +
            "                </div>" +
            "                <div style=\"display: flex;justify-content:center\" class=\"cart-success__subtitle\">";
        public static string RenderHTML(HDBanEntity hd)
        {
            string s1 = "Mã đơn hàng của bạn:" + hd.GhiChu +
            "                </div>" +
            "            </div>";
            string cthd = "<tr>";
            for(int i =0;i < hd.CTHDBans.Count; i++)
            {
                cthd = cthd + "<td>" + hd.CTHDBans[i].TenSP + "</td>" +
                    "<td>" + hd.CTHDBans[i].TenSP + "</td>" +
                    "<td>" + hd.CTHDBans[i].SoLuong + "</td>" +
                    "<td>" + hd.CTHDBans[i].Size+ hd.CTHDBans[i].MauSac + "</td>";
            }
            string s2 = "<div class=\"cart-success__body\">" +
            "                <p>Thông tin đơn hàng:</p>" +
            "                <table class=\"table table-bordered\">" +
            "                    <thead>" +
            "                       <tr>" +
            "                            <th>Tên sản phẩm</th>" +
            "                            <th>Số lượng</th>" +
            "                            <th>Thuộc tính</th>" +
            "                        </tr>" +
            "                   </thead>" +
            "                    <tbody>" +
                                    cthd +
            "                        <tr>" +
            "                           <td class=\"cart-success__item-title\" colspan=\"2\">Tổng giá trị sản phẩm</td>" +
            "                            <td>"+hd.TongTien+" đ</td>" +
            "                        </tr>" +
            "                        <tr>" +
            "                            <td class=\"cart-success__item-title\" colspan=\"2\">Phí Ship</td>" +
            "                            <td>0đ</td>" +
            "                        </tr>" +
            "                        <tr>" +
            "                            <td class=\"cart-success__item-title\" colspan=\"2\">Tổng thanh toán</td>" +
            "                            <td style=\"color: orangered\">"+hd.TongTien+" đ</td>" +
            "                    </tbody>" +
            "                </table>";
            string s3 = " <p> Thông tin nhận hàng:</p> " +
            "                <div class=\"cart-success__addresss\">" +
            "                    <div class=\"cart-success__address-group\">" +
            "                        <label for=\"\" class=\"cart-success__address-label\">Người nhận :</label>" +
            "                        <p id=\"tennguoinhan\" class=\"cart-success__address-content\">" + hd.DiaChi.NguoiNhan + "</p>" +
            "                    </div>" +
            "                    <div class=\"cart-success__address-group\">" +
            "                        <label for=\"\" class=\"cart-success__address-label\">" +
            "                            Số điện thoại :" +
            "                        </label>" +
            "                        <p id=\"sdt\" class=\"cart-success__address-content\">" + hd.DiaChi.SoDT + "</p>" +
            "                    </div>" +
            "                    <div class=\"cart-success__address-group\">" +
            "                        <label for=\"\" class=\"cart-success__address-label\">Địa chỉ:</label>" +
            "                        <p id=\"diachi\" class=\"cart-success__address-content\">" + hd.DiaChi.DiaChiNH + "</p>" +
            "                    </div>" +
            "                </div>" +
            "            </div>" +
            "            <div class=\"cart-success__footer\"></div>" +
            "        </div>" +
            "    </div>" +
            "</body>" +
            "</html>";
            string result = Header + s1 + s2 + s3;
            return result;
        }
    }
}
