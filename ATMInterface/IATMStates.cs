using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMInterface
{
    public interface IATMStates
    {
        public void EnterPin(int pin);
        public void InsertCard();
        public void RemoveCard();
        public void SelectTransaction(string transaction, double amount);
    }
}
