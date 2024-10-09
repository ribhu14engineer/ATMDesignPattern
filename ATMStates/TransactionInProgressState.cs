using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class TransactionInProgressState : IATMStates
    {
        private readonly IATMContext _atmContext;
        private IDispenser _dispense500;
        private IDispenser _dispense100;
        public TransactionInProgressState(IATMContext atmContext)
        {
            _atmContext = atmContext;
            _dispense500 = new Rs500Dispenser();
            _dispense100 = new Rs100Dispenser();

            _dispense500.setNext(_dispense100);
        }
        public void EnterPin(int pin)
        {
            Console.WriteLine("PIN Already Entered");
        }

        public void InsertCard()
        {
            Console.WriteLine("Card Already Inserted");
        }

        public void RemoveCard()
        {
            Console.WriteLine("Trasaction Cancelled becoz card has been removed. Thankyou for choosing this atm");
            _atmContext.SetState(_atmContext.IdleState);
        }

        public void SelectTransaction(string transaction, double amount)
        {
            bool isTransactionSuccessfull;

            Console.WriteLine($"Money to withdraw {amount}");

            _dispense500.Dispense(amount, out isTransactionSuccessfull);

            if (isTransactionSuccessfull)
            {
                _atmContext.SetState(_atmContext.TransactionCompletedState);
            }
            else
            {
                _atmContext.SetState(_atmContext.TransactionFailedState);
            }
        }
    }
}
