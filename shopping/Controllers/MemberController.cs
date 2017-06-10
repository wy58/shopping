using shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace shopping.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        //会员注册页面
        MvcShoppingContext db = new MvcShoppingContext();
        public ActionResult Register()
        {
            return View();
        }
        //密码哈希所需的salt随机数值
        private string pwSalt = "AlryAqloPe2Mh784QQwG6jRAfkdPpDa90J0i";

        //写入会员资料


        //[HttpPost]
        //public ActionResult Register([Bind(Exclude = "RwgisterOn,AuthCode")]Member member)
        //{
        //    var chk_member = db.Members.Where(p => p.Email == member.Email).FirstOrDefault();
        //    if (chk_member != null)
        //    {
        //        ModelState.AddModelError("Email", "您输入的Email已经有人注册过了！");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        member.password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + member.password, "SHA1");
        //        member.RegisterOn = DateTime.Now.ToString();
        //        member.AuthCode = null;
        //        db.Members.Add(member);
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        //ModelState.AddModelError("Email", "您输");
        //        //return View();
        //        return Content("h");
        //    }
        //}
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            string Ea = collection["Em"];
            string passw = collection["pa"];
            string name = collection["nm"];
            List<Members> mber = db.Members.ToList();

            if (mber.Count == 0)
            {
                //max=
                //Member member = new Member();
                //member.RegisterOn = DateTime.Now.ToString();
                var nm = from m in db.Members where m.Email == Ea select m;
                if (nm.Count() != 0)
                {
                    Response.Write("<script>alert('您输入的Email已经有人注册过了！');</script>");
                    return View();
                }
                else
                {
                    Members member = new Members { Id = 1, Email = Ea, password = passw, Name = name, RegisterOn = DateTime.Now.ToString() };
                    db.Members.Add(member);
                    db.Configuration.ValidateOnSaveEnabled = false;  // 错误:对一个或多个实体的验证失败。有关详细信息，请参见“EntityValidationErrors”属性
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                    Response.Write("<script>alert('注册成功！');</script>");
                    return View("login");
                }
            }
            else
            {
                int max = db.Members.Select(p => p.Id).Max();
                //Member member = new Member();
                //member.RegisterOn = DateTime.Now.ToString();
                var nm = from m in db.Members where m.Email == Ea select m;
                if (nm.Count() != 0)
                {
                    Response.Write("<script>alert('您输入的Email已经有人注册过了！');</script>");
                    return View();
                }
                else
                {
                    Members member = new Members { Id = max + 1, Email = Ea, password = passw, Name = name, RegisterOn = DateTime.Now.ToString() };
                    db.Members.Add(member);
                    db.Configuration.ValidateOnSaveEnabled = false;  // 错误:对一个或多个实体的验证失败。有关详细信息，请参见“EntityValidationErrors”属性
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                    Response.Write("<script>alert('注册成功！');</script>");
                    return View("login");
                }
            }
            
            

        }
        public ActionResult login()
        {
            Session["lg"] = "已经登录";
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection collection)
        {
            string name = collection["txt"];
            string pas = collection["pas"];
            var m = from c in db.Members where c.Email == name && c.password == pas select c;
            if (m.Count() != 0)
            {
                //Response.Write("<script>alert('登录成功！');</script>");
                Session["lg"] = "已经登录";
                return View("");
            }
            else
            {
                var n = from v in db.Members where v.Email == name && v.password != pas select v;
                if (n.Count() != 0)
                {
                    Response.Write("<script>alert('密码错误！');</script>");

                }
                else
                {
                    Response.Write("<script>alert('登录失败！');</script>");
                }
                return View();
            }

        }


        //购物车
        public ActionResult GWC()
        {
            return View();
        }
    }
}
