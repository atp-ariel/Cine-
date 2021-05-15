using System.Collections.Generic;
using System.Collections;

namespace APIBank.Models{
    public interface ICashier{
        IResponse Transfer(Dictionary<string, object> transferAction);
        IResponse Consult(Dictionary<string, object> consultAction);
    }
}