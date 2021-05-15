using System;

namespace APIBank.Models{
    public class BernoulliVariable
    {
        #region Fields
        double _p = 0.5;
        #endregion Fields

        #region Properties
        private Random Rnd { get; set; }
        public double P => this._p;
        #endregion Properties

        #region Constructor
        public BernoulliVariable(double p)
        {
            if (p < 0 && p > 1)
                throw new Exception("A probabilty must be on [0,1] interval");
            this._p = p;
            this.Rnd = new Random(Guid.NewGuid().GetHashCode());
        }
        #endregion Constructor

        #region Methods
        public int GetX()
        {
            var U = this.Rnd.NextDouble();
            return U < this.P ? 1 : 0;
        }
        #endregion
    }
}