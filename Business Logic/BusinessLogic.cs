using Business_Logic.BL_Struct;
using Business_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL() 
        {
            return new SessionBL();
        }
        public IProduct GetProductBl()
        {
            return new ProductBL();
        }
        public IReg GetRegBL() 
        {
            return new RegBL();
        }

        public IAdmin GetAdminBl()
        {
            return new AdminBl();
        }
    }
}
