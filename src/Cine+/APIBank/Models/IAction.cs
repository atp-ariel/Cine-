using System.Collections.Generic;
using System.Collections;


namespace APIBank.Models
{
    public interface IAction
    {
        IResponse Response{get;set;}

        Dictionary<string, object> Data();

        void Do();
    }
}