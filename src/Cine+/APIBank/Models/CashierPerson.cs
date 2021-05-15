using System.Collections.Generic;
using System.Collections;

namespace APIBank.Models{
    public class CashierPerson : ICashier
    {
        public IResponse Transfer(Dictionary<string, object> dataTransfer)
        {
            IAction _transfer = new Transfer(dataTransfer);
            _transfer.Do();
            return _transfer.Response;
        }
        
        public IResponse Consult(Dictionary<string, object> dataConsult)
        {
            //IAction _transfer = new Consult(dataConsult);
            //_transfer.Do();
            //return _transfer.Response;
            return null;
        }
    }
}