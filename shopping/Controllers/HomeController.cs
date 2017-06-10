using shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
namespace shopping.Controllers
{
    public class HomeController : Controller
    {
        MvcShoppingContext db = new MvcShoppingContext();
        public ActionResult MyView()
        {

            return View();
        }
        public ActionResult Index()
        {
            //db.Database.Delete();//清空表
            return View("MyView");
        }
        public ActionResult iPhone()
        {
            //List<Product2> list = GetAll().ToList();
           
            
            
            //ViewBag["lis"]= m.SingleOrDefault();
            //DataTable dt = (DataTable)ViewBag.Data;
            //Response.Write("<script>alert('"+dt.Rows.Count+"！');</script>");
            return View();
        }
        public ActionResult GetAll()
        {
            List<Product2> lis = GetAllA().ToList();
            return PartialView(lis);

        }

        public ActionResult iPhon2()
        {
            List<Product2> list =GetAlliPhone().ToList();
            return PartialView(list);
        }

        public ActionResult HW()
        {
            List<Product2> lis = GetAllHW().ToList();
            return PartialView(lis);
        }

        public ActionResult JL()
        {
            List<Product2> lis = GetAllJL().ToList();
            return PartialView(lis);
        }

        //选中商品页面
        public ActionResult AddG(int id)
        {
           // Product2 pro = db.Products2.Where(p => p.Id == id).FirstOrDefault();
            Product2 pro = GetAllA().Where(p => p.Id == id).FirstOrDefault();
            return View(pro);
        }

        public ActionResult GWC0()
        {
            List<Cartcs> carts = db.Cartcs.ToList();
                return View(carts);
        }

        //public ActionResult GWC(FormCollection collection)
        //{
        //    string txt = collection["inText"];

        //}

        //购物车 
        [HttpPost]
        public ActionResult GWC(int id,FormCollection collection)
        {
            //int idd = db.Cartcs.Max().Id;
            //Response.Write("<script>alert('该商品已经加入购入车！');</script>");
            int txt =int.Parse(collection["intex"]);
            Product2 pro = GetAllA().Where(p => p.Id == id).FirstOrDefault();
           // List<Cartcs> cat = db.Cartcs.ToList();
            var m = from e in db.Cartcs where e.mid==id select e;
            int max;
            
            if (m.Count()!=0)
            {
                Response.Write("<script>alert('该商品已经加入购入车！');</script>");
                Response.Write("<script>alert('"+id+"');</script>");
                return View("MyView");
            }
            else
            {
                if (db.Cartcs.Count() == 0)
                {
                    max = 0;
                    Cartcs cartcs = new Cartcs { Id = max ,mid=id, Product = pro.Name, Amount = txt, ImageUrl = pro.ImageUrl, Description = pro.Description, Price = pro.Price };
                    db.Cartcs.Add(cartcs);
                    db.SaveChanges();
                }
                else
                {
                    max = db.Cartcs.Select(p => p.Id).Max();
                   Cartcs cartcs = new Cartcs { Id = max + 1,mid=id, Product = pro.Name, Amount = txt, ImageUrl = pro.ImageUrl, Description = pro.Description, Price = pro.Price };
                   db.Cartcs.Add(cartcs);
                   db.SaveChanges();
                }
                
            }
         
                List<Cartcs> carts = db.Cartcs.ToList();
                return View("GWC0", carts);
        }
        //删除购物车

        public ActionResult RemoveG(int id)
        {
            //Response.Write("<script>alert('"+id+"');</script>");
            //id = 1;
            Cartcs car = db.Cartcs.Where(p => p.Id == id).FirstOrDefault(); ;

            if (car != null)
            {
                db.Cartcs.Remove(car);
                db.SaveChanges();
            }
            return RedirectToAction("GWC0");
        }
        //删除购物车
        public ActionResult RemoveAll()
        {
            string deleteSql = "TRUNCATE TABLE dbo.Cartcs";
            //ExecuteSqlCommand方法对数据库执行指定的ddl/dml命令
            db.Database.ExecuteSqlCommand(deleteSql);//删除购物车
            return RedirectToAction("GWC0");
        }
        //结算
        //[HttpPost]
        //public ActionResult SumAll()
        //{
        //}
       
        //商品
        private List<Product2> GetAlliPhone()
        {
            return new List<Product2>
            {
                new Product2(){Id=0,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i1.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=1,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i1.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=2,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i2.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=3,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i3.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=4,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i4.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=5,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i5.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=6,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i6.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=7,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i7.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=8,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i8.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=9,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i9.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=10,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=11,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=12,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=13,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=14,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=15,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=16,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000}
            };
        }

        private List<Product2> GetAllHW()
        {
            return new List<Product2>
            {
                new Product2(){Id=17,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=18,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=19,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=20,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=21,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=22,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=23,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=24,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=25,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=26,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=27,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=28,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=29,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=30,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000}
            };
        }

        private List<Product2> GetAllJL()
        {
            return new List<Product2>
            {
                new Product2(){Id=31,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=32,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=33,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=34,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=35,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=36,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=37,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=38,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=39,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=40,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=41,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=42,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=43,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=44,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000}
            };
        }

        private List<Product2> GetAllA()
        {
            return new List<Product2>
            {
                new Product2(){Id=1,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i1.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=2,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i2.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=3,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i3.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=4,Description="产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",ImageUrl="/Images/i4.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=5,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i5.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=6,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i6.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=7,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i7.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=8,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i8.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=9,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i9.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=10,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=11,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=12,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=13,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=14,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=15,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=16,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                 new Product2(){Id=17,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=18,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=19,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=20,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=21,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=22,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=23,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=24,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=25,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=26,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=27,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=28,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=29,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=30,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                 new Product2(){Id=31,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=32,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=33,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=34,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=35,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=36,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=37,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=38,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=39,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=40,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=41,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=42,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=43,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000},
                new Product2(){Id=44,Description="产品描述产品描述产品描述产品描述",ImageUrl="/Images/i10.jpg",Name="iPhone",Price=2000}
            };
        }
    }
}
