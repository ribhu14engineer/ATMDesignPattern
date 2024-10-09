using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public interface IATMStates
    {
        public void InsertCard();
        public void RemoveCard();
        public void EnterPin(int pin);
        public void SelectTransaction(string transaction, double amount);
    }
}
