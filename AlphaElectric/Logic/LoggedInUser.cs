using AIS_DataAccessLayer;

namespace AIS.Logic
{
    public class LoggedInUser
    {
        public Login Info;
        public void RemoveData()
        {
            Info = null;
        }
        private static LoggedInUser instance;

        private LoggedInUser() { }

        public static LoggedInUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggedInUser();
                }
                return instance;
            }
        }

        
    }
}
