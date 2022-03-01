using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Common;

namespace Model.Dao
{
    public class UserDao
    {
        MyDB db = new MyDB();
        public List<TaiKhoan> GetList()
        {
            return db.TaiKhoans.ToList();
        }
        
        public int Login(string username,string password,bool isLoginAdmin=false)
        {
            var result = db.TaiKhoans.SingleOrDefault(x => x.TaiKhoan1 == username);
            if(result==null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if(result.IDQuyen == CommonConstants.ADMIN_GROUP || result.IDQuyen == CommonConstants.MOD_GROUP)
                    {
                        if (result.TrangThai == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.MatKhau == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.TrangThai == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.MatKhau == password)
                            return 1;
                        else
                            return -2;
                    }
                   
                }
               
            }
        }
        public TaiKhoan GetByUsername(string username)
        {
            return db.TaiKhoans.SingleOrDefault(x=>x.TaiKhoan1==username);
        }
        public long Insert(TaiKhoan user)
        {
            db.TaiKhoans.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public bool Update(TaiKhoan entity)
        {
            var taikhoan = db.TaiKhoans.Find(entity.ID);
            taikhoan.TaiKhoan1 = entity.TaiKhoan1;
            taikhoan.NgaySua = DateTime.Now;
            if(!string.IsNullOrEmpty(entity.MatKhau))
            {
                taikhoan.MatKhau = entity.MatKhau;
            }
            taikhoan.Ten = entity.Ten;
            taikhoan.IDQuyen = entity.IDQuyen;
            db.SaveChanges();
            return true;
        }
        public TaiKhoan Find(long id)
        {
            return db.TaiKhoans.Find(id);
        }
        public bool Delete(long id)
        {
            try
            {
                var taikhoan = db.TaiKhoans.Find(id);
                db.TaiKhoans.Remove(taikhoan);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool CheckUserName(string userName)
        {
            return db.TaiKhoans.Count(x => x.TaiKhoan1 == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.TaiKhoans.Count(x => x.Email == email) > 0;
        }
    }
}
