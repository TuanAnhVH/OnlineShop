using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class SlideDAO
    {
        public List<Slide> ListAll()
        {
            return Dbo.Db.Slide.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
