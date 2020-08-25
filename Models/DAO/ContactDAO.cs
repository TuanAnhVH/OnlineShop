using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ContactDAO
    {
        public Contact GetActiveContact()
        {

            return Dbo.Db.Contact.SingleOrDefault(x => x.Status == true);
        }

        public int InsertFeedback(Feedback feed)
        {
            Dbo.Db.Feedback.Add(feed);
            Dbo.Db.SaveChanges();
            return feed.ID;
           
        }
    }
}
