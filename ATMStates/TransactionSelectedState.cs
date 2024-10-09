using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class TransactionSelectedState : IATMStates
    {
        private readonly IATMContext _atmContext;
        public TransactionSelectedState(IATMContext atmContext)
        {
            _atmContext = atmContext;
        }
        public void EnterPin(int pin)
        {
            Console.WriteLine("PIN Already Entered");
        }

        public void InsertCard()
        {
            Console.WriteLine("Card Already Inserted...");
        }

        public void RemoveCard()
        {
            Console.WriteLine("Card is being removed. Going to Idle state... Thankyou for choosing this ATM.");
            _atmContext.SetState(_atmContext.IdleState);
        }

        public void SelectTransaction(string transaction, double amount)
        {
            if (transaction.ToLower() == "withdraw")
            {
                Console.WriteLine($"Transaction type is {transaction} and hence moving to TransactionInprogressState");
                _atmContext.SetState(_atmContext.TransactionInProgressState);
            }
            else
            {
                Console.WriteLine("Invalid Transaction type....Cancelling the Transaction. Going to Transaction Failed state");
                _atmContext.SetState(_atmContext.TransactionFailedState);
            }
        }
    }
}
