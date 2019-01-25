using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices.Interfaces
{
    public interface ITariffManager<out T1>
    {
        T1 Manage();
    }
    public interface ITariffManager<in T1,out T2>
    {
        T2 Manage(T1 id);
    }
}
