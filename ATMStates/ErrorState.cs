using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class ErrorState : IATMStates
    {
        private readonly IATMContext _atmContext;
        public ErrorState(IATMContext atmContext)
        {
            _atmContext = atmContext;
        }
        public void EnterPin(int pin)
        {
            throw new NotImplementedException();
        }

        public void InsertCard()
        {
            throw new NotImplementedException();
        }

        public void RemoveCard()
        {
            throw new NotImplementedException();
        }

        public void SelectTransaction(string transaction, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
