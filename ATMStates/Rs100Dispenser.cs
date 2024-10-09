using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class Rs100Dispenser : IDispenser
    {
        private IDispenser _nextDispenser;
        public void Dispense(double amount, out bool isTransactionSuccessfull)
        {
            if(amount <= ATMInitiation.TotalCashInATM())
            {
                if (amount >= 100)
                {
                    int numNotes = (int)(amount) / 100;
                    int remainder = (int)(amount) % 100;

                    if (numNotes <= ATMInitiation.Rs100NotesCount)
                    {
                        ATMInitiation.Rs100NotesCount -= numNotes;
                        if (remainder !=0 && _nextDispenser != null)
                        {
                            _nextDispenser.Dispense(remainder, out isTransactionSuccessfull);
                        }
                        else
                        {
                            isTransactionSuccessfull = false;
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
                    if (_nextDispenser != null)
                    {
                        _nextDispenser.Dispense(amount, out isTransactionSuccessfull);
                    }
                    else
                    {
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
