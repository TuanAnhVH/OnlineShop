using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class FooterDAO
    {
        public Footer GetFooter()
        {
          return  Dbo.Db.Footer.SingleOrDefault(x => x.Status == true);
        }
    }
}
