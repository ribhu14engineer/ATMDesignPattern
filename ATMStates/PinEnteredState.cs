using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class PinEnteredState : IATMStates
    {
        private readonly IATMContext _atmContext;
        public PinEnteredState(IATMContext atmContext)
        {
           _atmContext = atmContext;
        }
        public void EnterPin(int pin)
        {
            Console.WriteLine("PIN already Inserted.");
        }

        public void InsertCard()
        {
           Console.WriteLine("Card alreDy Inserted.");
        }

        public void RemoveCard()
        {
            Console.WriteLine("Card is being removed. Going to Idle State. Thankyou for choosing this ATM.");
            _atmContext.SetState(_atmContext.IdleState);
        }

        public void SelectTransaction(string transactionType, double amount)
        {
            Console.WriteLine($"The transaction type is {transactionType} and amount is {amount}. Now going to TransactionSelectedState.");
            _atmContext.SetState(_atmContext.TrasactionSelectState);
        }
    }
}
