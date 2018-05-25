using ShopOnline.code;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace ShopOnline.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Admin/Account/
        public ActionResult test()
        {
            return View();
        }
        public ActionResult Index(string CurrentFilter, string searchString, int? page)
        {
            //var namesearch = new AccountModel().search(seachby);
            //var ListAcc = new AccountModel();
            //ViewBag.ViewInfo = ListAcc.ListCustom(page, pageSize);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var model = new AccountModel().ListCustom();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NameAcc.Contains(searchString));
            }
            model = model.OrderBy(x => x.IDAcc);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Mod(int page = 1, int pageSize = 10)
        {
            var listacc = new AccountModel();
            ViewBag.ViewInfo = listacc.ListMod(page, pageSize);
            return View();
        }
        public ActionResult Founder(int page = 1, int pageSize = 10)
        {
            var ListAcc = new AccountModel();
            ViewBag.ViewInfo = ListAcc.ListFounder(page,pageSize);
            return View();
        }
        #region UpdateAcc
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var DAO = new AccountModel();
            var result = DAO.GetdataAcc(ID);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(TblAccount Acc)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountModel();
                var EncrypMd5 = Encryption.MD5Hash(Acc.PassAcc);
                Acc.PassAcc = EncrypMd5;
                var result = DAO.Update(Acc);
                if (result)
                {
                    SetAlert("Cập nhật tài khoản thành công", "success");
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("error", "*Lỗi khi cập nhật tài khoản " + Acc.NameAcc + " . Liên hệ Founder");
                }
            }
            return View("Edit");
        }
        #endregion
        #region Create Acc
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TblAccount Acc)
        {
            if(ModelState.IsValid)
            {
                var DAO = new AccountModel();
                if (DAO.GetIDUser(Acc.NameAcc)!= null)
                {
                    ModelState.AddModelError("error", "*Tài khoản "+Acc.NameAcc+" đã tồn tại");
                }
                else
                {
                    var ErcryMD5 = Encryption.MD5Hash(Acc.PassAcc);
                    Acc.PassAcc = ErcryMD5;
                    int id = DAO.Insert(Acc);
                    if (id > 0)
                    {
                        SetAlert("Thêm tài khoản thành công", "success");
                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("error", "*Lỗi khi thêm tài khoản" + Acc.NameAcc + ". Liên hệ Founder");
                    }
                }
             }
            return View("Create");
        }
        #endregion
        #region Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AccountModel().Delete(id);
            SetAlert("Xóa tài khoản thành công", "success");
            return RedirectToAction("Index", "Account");
        }
        #endregion
    }
}