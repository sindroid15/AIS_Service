using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class ContactFactory
    {
        ContactDA conDa;

        public ContactFactory()
        {
            conDa = new ContactDA();
        }

        public List<Contact> SelectAll()
        {
            return conDa.SelectAll();
        }

        public bool InsertContact(Contact con)
        {
            return conDa.InsertContact(con);
        }

        public bool Update(int id, string name, string phone, string email, string address)
        {
            return conDa.Update(id, name, phone, email, address);
        }
    }
}
