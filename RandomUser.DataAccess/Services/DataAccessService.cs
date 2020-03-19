using RandomUser.DataAccess.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.DataAccess.Services
{
    public abstract class DataAccessService: AutoMapperBase, IDisposable
    {
        protected RandomUserStoreEntities DbContext;
        public DataAccessService()
        {
            DbContext = new RandomUserStoreEntities();
        }

        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }
    }
}
