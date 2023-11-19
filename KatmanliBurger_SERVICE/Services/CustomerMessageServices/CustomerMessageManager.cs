using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_SERVICE.Services.CustomerMessageServices
{
    public class CustomerMessageManager:ICustomerMessageService
    {
        private readonly ICustomerMessageDal _customerMessageDal;

        public CustomerMessageManager(ICustomerMessageDal customerMessageDal)
        {
            _customerMessageDal = customerMessageDal;
        }


        public void Create(CustomerMessage entity)
        {
            _customerMessageDal.Create(entity);
        }


        public IEnumerable<CustomerMessage> GetAll()
        {
            return _customerMessageDal.GetAll();
        }


        public CustomerMessage GetById(int id)
        {
            return _customerMessageDal.GetById(id);
        }



        public void Update(CustomerMessage entity)
        {
            _customerMessageDal.Update(entity);
        }



        public void UpdateStatus(int id)
        {
            var message = _customerMessageDal.GetById(id);
            message.Status = message.Status == Status.Active ? Status.Passive : Status.Active;
            message.UpdatedDate = DateTime.Now;
            _customerMessageDal.Update(message);
        }
    }
}
