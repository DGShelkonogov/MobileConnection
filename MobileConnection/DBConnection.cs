using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection
{
    public static class DBConnection
    {
        private static ApplicationContext db;

        public static ApplicationContext getConnection()
        {
            if(db == null)
                db = new ApplicationContext();
            return db;
        }
    }
}
