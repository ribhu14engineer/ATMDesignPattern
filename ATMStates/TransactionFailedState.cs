using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class TransactionFailedState : IATMStates
    {
        private readonly IATMContext _atmContext;
        public TransactionFailedState(IATMContext atmContext)
        {
            _atmContext = atmContext;
        }
        public void EnterPin(int pin)
        {
            Console.WriteLine("PIN has already been entered. But Transaction Failed");
        }

        public void InsertCard()
        {
            Console.WriteLine("Card has already been entered. But Transaction Failed");

        }

        public void RemoveCard()
        {
            Console.WriteLine("Card is being removed. Transaction failed going back to Idle State");
            _atmContext.SetState(_atmContext.IdleState);
        }

        public void SelectTransaction(string transaction, double amount)
        {
            Console.WriteLine("Transaction has already failed. Now ggoing back to Idle State");
            _atmContext.SetState(_atmContext.IdleState);
        }
    }
}
