using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using API_FashionShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        NhanVienBUS nhanvienBUS;
        FileService fileService;
        private IUserService _userService;

        public NhanVienController(AppDBContext db, IUserService userService)
        {
            nhanvienBUS = new NhanVienBUS(db);
            _userService = userService;
            fileService = new FileService();
        }
        [HttpGet]
        public Respone GetAll()
        {
            try
            {
                var result = nhanvienBUS.Gets();
                if (result == null)
                {
                    return new Respone(false, Status.NotFound);
                }
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPost]
        public Respone Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string loc = string.Empty;
                string email = string.Empty;
                if (formData.Keys.Contains("hoTen") && !string.IsNullOrEmpty(Convert.ToString(formData["hoTen"])))
                { loc = formData["hoTen"].ToString(); }
                if (formData.Keys.Contains("email") && !string.IsNullOrEmpty(Convert.ToString(formData["email"])))
                { email = formData["email"].ToString(); }
                List<NhanVien> list = nhanvienBUS.Gets();
                long total = list.Count();
                list = list.Where(x => x.HoTen!.ToLower().Contains(loc.ToLower())
                || x.Email!.ToLower().Contains(email.ToLower())
                ).
                    Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                return new Respone(true, Status.Success, string.Empty,
                           new DataSearch
                           {
                               page = page,
                               totalItem = total,
                               pageSize = pageSize,
                               data = list
                           }
                         );
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public Respone GetById(int id)
        {
            try
            {
                var result = nhanvienBUS.Get(id);
                if (result == null)
                {
                    return new Respone(false, Status.NotFound);
                }
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost()]
        public Respone Authenticate([FromBody] AuthenticateModel model)
        {
            try
            {
                var user = _userService.Authenticate(model.Username, model.Password);

                if (user == null)
                    return new Respone(false, Status.BadRequest, "Tài khoản hoặc mật khẩu sai!", model);

                return new Respone(true, Status.Success, "", user);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPost]
        public Respone Create(NhanVien o)
        {
            try
            {
                if (o.SoDT == string.Empty || o.Email == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = nhanvienBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, NhanVien o)
        {
            try
            {
                if (o.SoDT == string.Empty || o.Email == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result =nhanvienBUS.Update(o);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpDelete]
        public Respone Delete(int id)
        {
            try
            {
                var result = nhanvienBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }
        [HttpPost]
        public async Task<Respone> Upload(IFormFile f)
        {
            try
            {
                var result = await fileService.Upload(f, "Avatars");
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpGet]
        public ActionResult ReadFile(string path)
        {
            try
            {
                var result = fileService.Read(path);
                return File(result, "image/jpeg");
                //return new Respone(true, Status.Success, string.Empty, a);
            }
            catch (Exception ex)
            {
                //return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
                return null;
            }
        }
    }
}
