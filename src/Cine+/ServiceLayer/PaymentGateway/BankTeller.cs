using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.PaymentGateway
{
    public class BankTeller
    {
        public bool Pay()
        {
            var bernoulli = new BernoulliVariable(0.90);
            return Convert.ToBoolean(bernoulli.GetX());
        }
    }
}
