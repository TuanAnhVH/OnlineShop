using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ContentDAO
    {
        public Content getByID(long ID)
        {
            return Dbo.Db.Content.Find(ID);
        }
    }
}
