using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class PanelShellGradeProtectionDA
    {
        AlphaElectricEntitiesDB db;

        public PanelShellGradeProtectionDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<PanelShellGradeProtection> SelectAll()
        {
            return db.PanelShellGradeProtections.ToList();
        }

        public bool InsertPanelShellGradeProtection(PanelShellGradeProtection pgrade)
        {
            db.PanelShellGradeProtections.Add(pgrade);
            return db.SaveChanges() > 0 ? true : false;
        }


        public bool Delete(int id)
        {
            var pgrade = db.PanelShellGradeProtections.Where(x => x.ID == id).FirstOrDefault();
            if (pgrade != null)
            {
                db.PanelShellGradeProtections.Remove(pgrade);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string ipnum, string desLiq, string desSol)
        {
            var pgrade = db.PanelShellGradeProtections.Where(x => x.ID == id).FirstOrDefault();
            if (pgrade != null)
            {
                pgrade.IPNum = ipnum;
                pgrade.DescriptionLiquids = desLiq;
                pgrade.DescriptionSolids = desSol;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
        
    }
}
