using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class IdleState : IATMStates
    {
        private readonly IATMContext _atmContext;
        public IdleState(IATMContext atmContext)
        {
            _atmContext = atmContext;
        }

        public void EnterPin(int pin)
        {
            Console.WriteLine("Enter Card First before entering PIN.");
        }

        public void InsertCard()
        {
            Console.WriteLine("Card inserted. Transitioning to CardInsertedState.");
            _atmContext.SetState(_atmContext.CardInsertedState);
        }

        public void RemoveCard()
        {
            Console.WriteLine("Enter Card First before Removing Card.");
        }

        public void SelectTransaction(string transaction, double amount)
        {
            Console.WriteLine("Enter Card First before Transaction");
        }
    }
}
