using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class CertificationFactory
    {
        CertificationDA certDa;

        public CertificationFactory()
        {
            certDa = new CertificationDA();
        }

        public List<Certification> SelectAll()
        {
            return certDa.SelectAll();
        }

        public bool InsertCertification(Certification cert)
        {
            return certDa.InsertCertification(cert);
        }
    }
}
