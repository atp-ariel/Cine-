using System.Collections.Generic;
using System.Collections;

namespace APIBank.Models
{
    public class Transfer : IAction
    {
        Dictionary<string, object> _data;
        public Transfer(Dictionary<string, object> data){
            this._data = data;
            this.Response = new IResponse(){Status = StatusCode.Wait, ResultMessage = "Waiting for be process"};
        }
        public IResponse Response{get;set;}

        public Dictionary<string, object> Data() => _data;

        public void Do()
        {
            BernoulliVariable bernoulli = new BernoulliVariable(0.90);
            this.Response.Status = (StatusCode)(bernoulli.GetX() + (int)StatusCode.Error);
            this.Response.ResultMessage = this.Response.Status == StatusCode.OK ? "Done Transfer" : "Fail Transfer";
        }
    }
}