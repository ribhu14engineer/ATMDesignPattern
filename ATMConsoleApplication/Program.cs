using ATMContext;
using ATMInterface;
using ATMStates;
using System.Transactions;

namespace ATMConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter No of Rs500 Notes You want to Inject in ATM machine: ");
            int count500rsNotes = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter No of Rs100 Notes You want to Inject in ATM machine: ");
            int count100rsNotes = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Injecting Money in ATM");
            ATMInitiation atmInitiation = new ATMInitiation(count500rsNotes, count100rsNotes);

            Console.WriteLine("Enter the Total Amoount You  want to Withdraw: ");
            double amount = double.Parse(Console.ReadLine());


            var atm = new ATM(null, null, null, null, null, null, null, null);

            var idleState = new IdleState(atm);
            var cardInsertState = new CardInsertedState(atm);
            var pinEnteredState = new PinEnteredState(atm);
            var transactionSelectedState = new TransactionSelectedState(atm);
            var transactionInProgressState = new TransactionInProgressState(atm);
            var transactionCompletedState = new TransactionCompletedState(atm);
            var transactionFailedState = new TransactionFailedState(atm);
            var errorState = new ErrorState(atm);

            atm = new ATM(idleState, cardInsertState, pinEnteredState, transactionSelectedState,
                transactionInProgressState, transactionCompletedState, transactionFailedState, errorState);

            atm.InsertCard();
            int pin = int.Parse(Console.ReadLine());
            atm.EnterPin(pin);
            atm.ProcessTransaction("withdraw", amount);
        }
    }
}
