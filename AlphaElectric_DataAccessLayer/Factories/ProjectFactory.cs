using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class ProjectFactory
    {
        ProjectDA projDa;

        public ProjectFactory()
        {
            projDa = new ProjectDA();
        }

        public List<Project> SelectAll()
        {
            return projDa.SelectAll();
        }

        public bool InsertProject(Project proj)
        {
            return projDa.InsertProject(proj);
        }

        public bool Update(int id, string name, int statusID, DateTime de)
        {
            return projDa.Update( id,  name, statusID,  de);
        }
    }
}
