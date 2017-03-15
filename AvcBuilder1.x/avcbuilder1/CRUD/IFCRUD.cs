using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace avcbuilder1.CRUD
{
    interface IFCRUD
    {
        int Add();
        int Remove();
        int Update();
        DataTable Query();           
    }
}
