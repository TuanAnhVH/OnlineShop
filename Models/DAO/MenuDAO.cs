using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class MenuDAO
    {
        public List<Menu> ListByGroupID(int GroupID)
        {
            return Dbo.Db.Menu.Where(x => x.TypeID == GroupID&& x.Status==true).OrderBy(x=>x.DisplayOder).ToList();
        }
    }
}
