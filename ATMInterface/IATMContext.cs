using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMInterface
{
    public interface IATMContext
    {
        public IATMStates IdleState { get; }
        public IATMStates CardInsertedState { get; }
        public IATMStates PinEnteredState { get; }
        public IATMStates TrasactionSelectState { get; }
        public IATMStates TransactionInProgressState { get; }
        public IATMStates TransactionCompletedState { get; }
        public IATMStates TransactionFailedState { get; }
        public IATMStates ErrorState { get; }
        void SetState(IATMStates state);
        void ProcessTransaction(string transactionType, double amount);
        
    }
}
