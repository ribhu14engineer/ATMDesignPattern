using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMInterface
{
    public interface IDispenser
    {
        void setNext(IDispenser nextDispenser);
        void Dispense(double amount, out bool isTransactionSuccessfull);
    }
}
