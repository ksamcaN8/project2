using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class HostingUnit
    {
        static int stSerialKey { set; get; }
        int HostingUnitKey { get; }

        bool[][] Diray = new bool[12][];
        HostingUnit()
        {
            for (int i = 0; i < 12; i++)
            {
                Diray[i] = new bool[31];
                for (int j = 0; j < 31; j++)
                    Diray[i][j] = false;
            }
            stSerialKey = 0;
            HostingUnitKey = 0;
        }

        public override string ToString()
        {
            Console.WriteLine(this.HostingUnitKey);
            int k;
            for (int i = 0; i < 12; i++) // going through the months
            {
                k = 0;
                while (k < 31) // if the month didn't end:
                { // go through and find a serie of taken dates
                    goingTroughTheSchedule(ref k, 0, this.Diray, i);
                    k++;
                }
            }

            static void goingTroughTheSchedule(ref int k, int sum, bool[][] diary, int i)
            {
                while (k < 31 && diary[i][k] == true)
                {
                    sum++;
                    k++;
                }
                if (sum != 0)
                    Console.WriteLine("Beginning date: {0}/{1} , Ending date:{2}/{3} ", k - sum + 1, i, k, i);
            }
        }

        public int GetAnnualBusyDays()
        {

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
        }
    }
}
