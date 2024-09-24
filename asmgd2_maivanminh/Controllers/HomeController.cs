using asmgd2_maivanminh.Models;
using lab7_csharp4.helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;

namespace asmgd2_maivanminh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        WebsiteLazadaContext db = new WebsiteLazadaContext();
        private List<GioHang> carts
        {
            get
            {
                return HttpContext.Session.Get<List<GioHang>>("giohang");
            }
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") != null)
            {
                var Ilist = db.TbProducts.ToList();
                return View("sanpham",Ilist);
            }
            else
            {
                return View("DangNhap");
            }
        }
        [Route("giohang")]
        public IActionResult giohang()
        {
            var data = carts ?? new List<GioHang>();

            return View(data);
        }

        public IActionResult sanpham()
        {
            var Ilist = db.TbProducts.ToList();
            return View(Ilist);
        }
        public IActionResult Addtocart(int id)
        {
            var mycart = carts ?? new List<GioHang>();
            var item = mycart.SingleOrDefault(p => p.ProductId == id);
            var hanghoa = db.TbProducts.SingleOrDefault(p => p.ProductId == id);
            if (item == null)
            {
                item = new GioHang
                {
                    Descriptions = hanghoa.Descriptions,
                    ProductId = id,
                    ProductName = hanghoa.ProductName,
                    Price = hanghoa.Price,
                    Soluong = 1
                };
                mycart.Add(item);
            }
            else
            {
                item.Soluong++;
            }
            HttpContext.Session.Set("giohang", mycart);
            return RedirectToAction("giohang");
        }
        public IActionResult RemoveFromCart(int id)
        {
            var myCart = carts;
            var item = myCart.SingleOrDefault(p => p.ProductId == id);

            if (item != null)
            {
                myCart.Remove(item);
                HttpContext.Session.Set("giohang", myCart);
            }

            return RedirectToAction("giohang");
        }
        public IActionResult RemoveOneFromCart(int id)
        {
            var myCart = carts;
            var item = myCart.SingleOrDefault(p => p.ProductId == id);

            if (item != null)
            {
                if (item.Soluong > 1)
                {
                    item.Soluong--;
                    HttpContext.Session.Set("giohang", myCart);
                }
                else
                {
                    myCart.Remove(item);
                    HttpContext.Session.Set("giohang", myCart);
                }
            }

            return RedirectToAction("giohang");
        }
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(string username, string password)
        {

            var user = db.TbCustomers.FirstOrDefault(u => u.UserName == username );
            if (user != null )
            {
                HttpContext.Session.SetString("User", user.UserName);


                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
                return View();
            }
        }

    
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
