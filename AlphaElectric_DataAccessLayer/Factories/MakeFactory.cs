using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{
  
    public class MakeFactory
    {
        MakeDA mkDa;

        public MakeFactory()
        {
            mkDa = new MakeDA();
        }

        public List<Make> SelectAll()
        {
            return mkDa.SelectAll();
        }

        public bool InsertMake(Make mk)
        {
            return mkDa.InsertMake(mk);
        }
    }
}
