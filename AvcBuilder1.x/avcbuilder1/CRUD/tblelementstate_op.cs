using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvcDb.entities;
using mysqlDao_v1;
namespace avcbuilder1.CRUD
{
    class tblelementstate_op : tblelementstate, IFCRUD
    {
        mysqlDAO MysqlDao;
        public tblelementstate_op()
        {
            MysqlDao = FormConnectSrv.Instance.MySqlDao;

        }

        public int Add()
        {
            
            throw new NotImplementedException();
        }

        public DataTable Query()
        {
            throw new NotImplementedException();
        }

        public int Remove()
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
