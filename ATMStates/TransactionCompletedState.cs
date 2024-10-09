using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class TransactionCompletedState : IATMStates
    {
        private readonly IATMContext _atmContext;
        public TransactionCompletedState(IATMContext atmContext)
        {
            _atmContext = atmContext;            
        }
        public void EnterPin(int pin)
        {
            Console.WriteLine("PIN already Inserted");
        }

        public void InsertCard()
        {
            Console.WriteLine("Card Already Inserted");
        }

        public void RemoveCard()
        {
            Console.WriteLine("Transaction has been already completed..Going to Idle State");
            _atmContext.SetState(_atmContext.IdleState);
        }

        public void SelectTransaction(string transaction, double amount)
        {
            Console.WriteLine("Transaction Already being made");
        }
    }
}
