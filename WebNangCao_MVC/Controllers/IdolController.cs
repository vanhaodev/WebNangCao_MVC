using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebNangCao_MVC.Models.Idol;

namespace WebNangCao_MVC.Controllers
{
    public class IdolController : Controller
    {
        public static List<IdolProfile> idols = new List<IdolProfile>();
        public IdolController()
        {
            
        }
        public IActionResult Index()
        {
            return View("IdolMng", idols);
        }

        //==============================THÊM MỚI===============================\\
        public IActionResult AddNewIdol()
        {
            if(HttpContext.Session.GetInt32("isLogin") == 1 && HttpContext.Session.GetInt32("role") == ((int)UserRole.Admin))
            {
                return View("IdolAddNew");
            }
            ViewBag.Message = "Bạn không đủ thẩm quyền (yêu cầu admin)";
            return View("IdolMng", idols);
        }
        [HttpPost]
        public ActionResult AddNewIdol(string fullName, string avatar, string des)
        {
            idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), fullName, avatar, des));
            return View("IdolMng", idols);
        }

        //==============================SỬA===============================\\
        public IActionResult IdolEdit(string idolid)
        {
            if (HttpContext.Session.GetInt32("isLogin") == 1 && HttpContext.Session.GetInt32("role") == ((int)UserRole.Admin))
            {
                IdolProfile model = new IdolProfile();
                model.id = idolid;
                model.fullName = idols[idols.FindIndex(prod => prod.id == idolid)].fullName;
                model.avatar = idols[idols.FindIndex(prod => prod.id == idolid)].avatar;
                model.description = idols[idols.FindIndex(prod => prod.id == idolid)].description;
                return View("IdolEdit", model);
            }
            ViewBag.Message = "Bạn không đủ thẩm quyền (yêu cầu admin)";
            return View("IdolMng", idols);
        }
        [HttpPost]
        public ActionResult IdolEdit(IdolProfile request)
        {
            idols[idols.FindIndex(prod => prod.id == request.id)].fullName = request.fullName;
            idols[idols.FindIndex(prod => prod.id == request.id)].avatar = request.avatar;
            idols[idols.FindIndex(prod => prod.id == request.id)].description = request.description;
            ViewBag.Message = "Sửa thành công " + request.fullName;
            return View("IdolMng", idols);
        }
        //==============================XÓA===============================\\
        public IActionResult IdolDelete(string idolid)
        {
            if (HttpContext.Session.GetInt32("isLogin") == 1 && HttpContext.Session.GetInt32("role") == ((int)UserRole.Admin))
            {
                try
                {
                    idols.RemoveAt(idols.FindIndex(prod => prod.id == idolid));
                    ViewBag.Message = "Xóa thành công";
                }
                catch
                {
                    ViewBag.Message = "Có lỗi xảy ra";
                }
                return View("IdolMng", idols);
            }
            ViewBag.Message = "Bạn không đủ thẩm quyền (yêu cầu admin)";
            return View("IdolMng", idols);
        }
    }
}
