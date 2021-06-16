using System;

namespace ServiceLayer.PaymentGateway
{
    internal class BernoulliVariable
    {
        #region Fields
        double _p = 0.5;
        #endregion Fields

        #region Properties
        private Random Rnd { get; set; }
        internal double P => this._p;
        #endregion Properties

        #region Constructor
        internal BernoulliVariable(double p)
        {
            if (p < 0 && p > 1)
                throw new Exception("A probabilty must be on [0,1] interval");
            this._p = p;
            this.Rnd = new Random(Guid.NewGuid().GetHashCode());
        }
        #endregion Constructor

        #region Methods
        internal int GetX()
        {
            var U = this.Rnd.NextDouble();
            return U < this.P ? 1 : 0;
        }
        #endregion
    }
}