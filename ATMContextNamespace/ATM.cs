using ATMInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMContext
{
    public class ATM : IATMContext
    {
        public static int PIN = 1234;
        public IATMStates CurrentState { get; set; }
        public IATMStates IdleState { get; private set; }
        public IATMStates CardInsertedState { get; private set; }
        public IATMStates PinEnteredState { get; private set; }
        public IATMStates TrasactionSelectState { get; private set; }
        public IATMStates TransactionInProgressState {  get; private set; }
        public IATMStates TransactionCompletedState { get; private set; }
        public IATMStates ErrorState { get; private set; }
        public IATMStates TransactionFailedState { get; private set; }

        public ATM(
            IATMStates idleState,
            IATMStates cardInsertedState,
            IATMStates pinEnteredState,
            IATMStates transactionSelectState,
            IATMStates transactionInProgressState,
            IATMStates trasactionCompletedState,
            IATMStates transactionFailedState,
            IATMStates errorState)
        {
            IdleState = idleState;
            CardInsertedState = cardInsertedState;
            PinEnteredState = pinEnteredState;
            TrasactionSelectState = transactionSelectState;
            TransactionInProgressState = transactionInProgressState;
            TransactionCompletedState = trasactionCompletedState;
            TransactionFailedState = transactionFailedState;
            ErrorState = errorState;

            CurrentState = IdleState;
        }

        public void SetState(IATMStates newState)
        {
            CurrentState = newState;
        }
        public void ProcessTransaction(string transactionType, double amount)
        {
            CurrentState.SelectTransaction(transactionType, amount);
        }
        public void InsertCard() 
        { 
            CurrentState.InsertCard(); 
        }
        public void EnterPin(int pin) 
        { 
            CurrentState.EnterPin(pin); 
        }
        public void RemoveCard() 
        { 
            CurrentState.RemoveCard(); 
        }
    }
}
