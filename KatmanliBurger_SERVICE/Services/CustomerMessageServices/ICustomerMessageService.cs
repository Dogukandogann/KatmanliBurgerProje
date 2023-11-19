using KatmanliBurger_DATA.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_SERVICE.Services.CustomerMessageServices
{
    public interface ICustomerMessageService
    {
        void Create(CustomerMessage entity);
        void Update(CustomerMessage entity);
        void UpdateStatus(int id);
        CustomerMessage GetById(int id);
        IEnumerable<CustomerMessage> GetAll();
    }
}
