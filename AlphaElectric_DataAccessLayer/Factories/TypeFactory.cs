using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class TypeFactory
    {
        TypeDA typeDa;

        public TypeFactory()
        {
            typeDa = new TypeDA();
        }

        public List<Type> SelectAll()
        {
            return typeDa.SelectAll();
        }

        public bool InsertType(Type type)
        {
            return typeDa.InsertType(type);
        }
    }
}
