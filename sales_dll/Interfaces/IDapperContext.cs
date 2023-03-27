using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_dll.Interfaces
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
