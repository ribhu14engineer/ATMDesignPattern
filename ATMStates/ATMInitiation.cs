using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStates
{
    public class ATMInitiation
    {
        internal static int Rs500NotesCount { get; set; }
        internal static int Rs100NotesCount { get; set; }

        public ATMInitiation(int rs500NotesCount, int rs100NotesCount)
        {
            Rs500NotesCount = rs500NotesCount;
            Rs100NotesCount = rs100NotesCount;
        }

        public static double TotalCashInATM()
        {
            return (Rs500NotesCount * 500) + (Rs100NotesCount * 100);
        }


    }
}
