using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class CertificationDA
    {
        AlphaElectricEntitiesDB db;

        public CertificationDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Certification> SelectAll()
        {
            return db.Certifications.ToList();
        }

        public bool InsertCertification(Certification cert)
        {
            db.Certifications.Add(cert);
            return db.SaveChanges() > 0 ? true : false;
        }

  
        public bool Delete(int id)
        {
            var cert = db.Certifications.Where(x => x.ID == id).FirstOrDefault();
            if (cert != null)
            {
                db.Certifications.Remove(cert);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string name, string descrip)
        {
            var cert = db.Certifications.Where(x => x.ID == id).FirstOrDefault();
            if (cert != null)
            {
                cert.Name = name;
                cert.Description = descrip;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
