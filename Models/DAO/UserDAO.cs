using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;


namespace Models.DAO
{
    public class UserDAO
    {
        public IEnumerable<User> ListAllPaging(String SearchString, int page, int PageSize)
        {
           IQueryable<User> model = Dbo.Db.User;

            if (!String.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.UserName.Contains(SearchString) || x.Name.Contains(SearchString));
            }

            return model.OrderBy(x => x.ID).ToPagedList(page, PageSize);
        }
        public long Insert(User entity)
        {
            var rs = Dbo.Db.User.SingleOrDefault(x => x.UserName == entity.UserName);
            if (rs == null)
            {
                Dbo.Db.User.Add(entity);
                Dbo.Db.SaveChanges();
                return entity.ID;
            }
            else
                return 0;

        }

        public bool Update(User Entity)
        {
            try
            {
                User u = Dbo.Db.User.Find(Entity.ID);
                if (u != null)
                {
                    u.Name = Entity.Name;
                    u.Password = Entity.Password;
                    u.Phone = Entity.Phone;
                    u.Address = Entity.Address;
                    u.Email = Entity.Email;
                    u.ModifiedDate = DateTime.Now;
                    u.Status = Entity.Status;
                    Dbo.Db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public bool Delete(int ID)
        {
            try
            {
                User u = Dbo.Db.User.Find(ID);
                Dbo.Db.User.Remove(u);
                Dbo.Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public User GetByID(int ID)
        {
            return Dbo.Db.User.Find(ID);
        }
        public User GetByUserName(string username)
        {
            User us = Dbo.Db.User.SingleOrDefault(x => x.UserName == username);
            return us;
        }
        public bool ChangeStatus(long id)
        {
            var user = Dbo.Db.User.Find(id);
            user.Status = !user.Status;
            Dbo.Db.SaveChanges();
            return user.Status;
        }
        public int Login(string user, string pass)
        {
            var res = Dbo.Db.User.SingleOrDefault(x => x.UserName == user);
            if (res == null)
                return 0;
            else
            {
                if (res.Password != pass)
                    return 1;
                else if (res.Status == false)
                {
                    return 2;
                }
                else
                    return 3;
            }

        }

        public bool checkUserName(string userName)
        {
            return Dbo.Db.User.Count(x => x.UserName == userName)>0;
        }

        public bool checkEmail(string Email)
        {
            return Dbo.Db.User.Count(x => x.Email== Email) > 0;
        }
    }
}
