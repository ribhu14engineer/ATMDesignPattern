using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class Rs500Dispenser : IDispenser
    {
        private IDispenser _nextDispenser;
        bool isTransactionSuccessfull;
        public void Dispense(double amount, out bool isTransactionSuccessfull)
        {
            if(amount <= ATMInitiation.TotalCashInATM())
            {
                if (amount >= 500)
                {
                    int numNotes = (int)(amount / 500);
                    int remainder = (int)(amount) % 500;

                    if (numNotes <= ATMInitiation.Rs500NotesCount)
                    {
                        ATMInitiation.Rs500NotesCount -= numNotes;
                        if (remainder != 0 && _nextDispenser != null)
                        {
                            _nextDispenser.Dispense(remainder, out isTransactionSuccessfull);
                        }
                        else
                        {
                            isTransactionSuccessfull = true;
                        }
                    }
                    else
                    {
                        if(_nextDispenser != null)
                        {
                            _nextDispenser.Dispense(amount, out isTransactionSuccessfull);
                        }
                        else
                        {
                            isTransactionSuccessfull=false;
                        }
                    }
                }
                else
                {
                    if(_nextDispenser != null)
                    {
                        _nextDispenser.Dispense(amount, out isTransactionSuccessfull);
                    }
                    else
                    {
                        Console.WriteLine("Transaction Cancelled...OUT OF CASH");
                        isTransactionSuccessfull = false;
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Transaction Cancelled...OUT OF CASH");
                isTransactionSuccessfull = false;
            }

        }

        public void setNext(IDispenser nextDispenser)
        {
            _nextDispenser = nextDispenser;
        }
    }
}
