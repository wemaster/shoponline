using ShopOnline.code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShopOnline.Models;
using PagedList;
namespace ShopOnline.Models
{
    public class AccountModel
    {
        private OnlineShopDbContext context = null;
        public AccountModel()
        {
            context = new OnlineShopDbContext();
        }
        public int Insert(TblAccount entityFrame)
        {
            context.TblAccounts.Add(entityFrame);
            context.SaveChanges();
            return entityFrame.IDAcc;
        }
        public TblAccount GetdataAcc(int ID)
        {
            return context.TblAccounts.Find(ID);
        }
        public bool Update(TblAccount entityFrame)
        {
            try
            {
                var idUser = context.TblAccounts.Find(entityFrame.IDAcc);
                idUser.NameAcc = entityFrame.NameAcc;
                string Pwd = Encryption.MD5Hash(entityFrame.PassAcc);
                if(!String.IsNullOrEmpty(Pwd))
                {
                    idUser.PassAcc = Pwd;
                }
                idUser.SDT = entityFrame.SDT;
                idUser.IDPer = entityFrame.IDPer;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public TblAccount GetIDUser(string Username)
        {
            return context.TblAccounts.SingleOrDefault(x => x.NameAcc == Username);
        }
        public bool Delete(int id)
        {
            try
            {
                var result = context.TblAccounts.Where(x => x.IDAcc == id).FirstOrDefault();
                context.TblAccounts.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public int Login(string Username, string PassWord)
        {
            string Pwd = Encryption.MD5Hash(PassWord);
            var result = context.TblAccounts.SingleOrDefault(x => x.NameAcc == Username);
            if (result == null )
            {
                return 0;//Tài khoản không tồn tại
            }
            else
            {
                if (result.PassAcc == Pwd)
                    return 1;// Đăng nhập thành công
                else
                    return -1;//Mật khẩu sai
            }
        }
        public List <AccountViewModel> ListMod(int page, int pageSize)
        {
            var list = from a in context.TblAccounts
                       join b in context.TblPers
                       on a.IDPer equals b.IDPer
                       where a.IDPer != 1 && a.IDPer != 2 && a.IDPer != 3
                       select new AccountViewModel()
                       {
                           IDAcc = a.IDAcc,
                           NameAcc = a.NameAcc,
                           DayRegister = a.DayReg,
                           IDPermis = a.IDPer,
                           NamePer = b.NamePer,
                           SDT = a.SDT
                       };
            return list.OrderByDescending(x=> x.DayRegister).ToPagedList(page, pageSize).ToList();
        }
        public IEnumerable<AccountViewModel> ListCustom()
        {
            //var list = context.Database.SqlQuery<TblAccount>("Pr_Account_View_Custom").ToList();
            var list = from a in context.TblAccounts
                       join b in context.TblPers
                       on a.IDPer equals b.IDPer
                       where a.IDPer != 1 && a.IDPer!= 2 && a.IDPer!= 3 
                       select new AccountViewModel()
                       {
                           IDAcc = a.IDAcc,
                           NameAcc = a.NameAcc,
                           DayRegister = a.DayReg,
                           IDPermis = a.IDPer,
                           NamePer = b.NamePer,
                           SDT = a.SDT
                       };
            return list;
        }
        public List<AccountViewModel> ListFounder(int page, int pageSize)
        {
            var list = from a in context.TblAccounts
                       join b in context.TblPers
                       on a.IDPer equals b.IDPer
                       where a.IDPer != 1 && a.IDPer != 2 && a.IDPer != 3
                       select new AccountViewModel()
                       {
                           IDAcc = a.IDAcc,
                           NameAcc = a.NameAcc,
                           DayRegister = a.DayReg,
                           IDPermis = a.IDPer,
                           NamePer = b.NamePer,
                           SDT = a.SDT
                       };
            return list.OrderByDescending(x => x.DayRegister).ToPagedList(page, pageSize).ToList();
        }
    }
}