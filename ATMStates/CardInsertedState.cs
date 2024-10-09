using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class CardInsertedState : IATMStates
    {
        private readonly IATMContext _atmContext;
        public CardInsertedState(IATMContext atmContext) 
        {
            _atmContext = atmContext;
        }
        public void EnterPin(int pin)
        {
            Console.WriteLine("Pleae Enter your Card Pin.: ");
            bool isPinParsed = int.TryParse(Console.ReadLine(), out int InputPIN);
            if (isPinParsed) 
            {
                if (InputPIN == 1234) 
                {
                    Console.WriteLine($"PIN is verified, now moving to the EnteredPINState...");
                    _atmContext.SetState(_atmContext.PinEnteredState);
                }
                else
                {
                    Console.WriteLine("Incorrect PIN Entered. Going to Transaction Failed State.");
                    _atmContext.SetState(_atmContext.TransactionFailedState);
                }
            }
            else
            {
                Console.WriteLine("Non Numeric Characters also entered...Going to Transaction Failed State.");
                _atmContext.SetState(_atmContext.TransactionFailedState);
            }
        }

        public void InsertCard()
        {
            Console.WriteLine("Card Already Inserted.");
        }

        public void RemoveCard()
        {
            Console.WriteLine("Card is being removed. Going to Idle state... Thankyou for choosing this ATM.");
            _atmContext.SetState(_atmContext.IdleState);
        }

        public void SelectTransaction(string transaction, double amount)
        {
            Console.WriteLine("Enter PIN First...");
        }
    }
}
