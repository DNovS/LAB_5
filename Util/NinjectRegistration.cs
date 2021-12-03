using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BLL.Interfaces;
using BLL.Service;
using BLL;

namespace LAB_5.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDBCrud>().To<DBDO>();
            Bind<IOrderService>().To<ServiceOrder>();
            Bind<IReportService>().To<ServiceReport>();
        }
    }
}
