using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class GuestRequest
    {
        public string EntryDate { get; set; }
        public string ReleaseDate { get; set; }
        public bool IsApproved { get; set; }
        public override string ToString()
        {
            string str = "";
            string strIsApproved = "";
            if (this.IsApproved == true)
                strIsApproved = "true";
            else
                strIsApproved = "false";
            str += "EntryDate:" + this.EntryDate + " ReleaseDate:" + this.ReleaseDate + " IsApproved:" + strIsApproved;
            return str;
        }
    }

    class HostingUnit:  // IComparable
    {
        static int stSerialKey { set; get; }
        public static int HostingUnitKey { get { return HostingUnitKey; } }

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
            // HostingUnitKey=0
        }

        public override string ToString()
        {
            string returnString = "the Hosting Unit's Serial number is: " + HostingUnitKey.ToString();
            // printing out all the days in the year when people come:
            int k; int sum = 0;
            for (int i = 0; i < 12; i++) // going through thr months
            {
                k = 0;
                while (k < 31) // if the month didn't end:
                { // go through and find a serie of taken dates
                    goingTroughTheSchedule(ref k, ref sum, Diray, i);
                    if (k < 31 && sum != 0)
                        if (sum > 31)
                            returnString+="Beginning date: " + (k + 31 * ((sum - k) / 31) - sum + 1) + "/" + (i - (sum - k) / 31 + 1) + "Ending date: "+ k + "/" + (i + 1);
                                else
                           returnString+="Beginning date: " + (k + 31 - sum + 1) + "/" + ((31 * (i + 1) - sum) / 31) + "Ending date: " + k+ "/" + (i + 1);
                    if (k < 31)
                    {
                        k++;
                        sum = 0;
                    }

                }
            }
            return returnString;
        }

        static void goingTroughTheSchedule(ref int k, ref int sum, bool[][] gestHouse, int i)
        {
            while (k < 31 && gestHouse[i][k] == true)
            {
                sum++;
                k++;
            }

        }

        /* public int CompareTo (object ab)
         {
             return (HostingUnitKey.CompareTo(((HostingUnit)ab).HostingUnitKey);
         }*/

       /* public bool ApproveRequest(GuestRequest guestReq)
        {
            int begain = int.Parse(guestReq.EntryDate);
            int end= int.Parse(guestReq.EntryDate);
            for(int i=begain; i<31 && i<end; i++)
                for

        }*/

        public int GetAnnualBusyDays()
        {
            return HostingUnitKey;
        }

        public float GetAnnualBusyPercentage()
        {
            return (float)100* HostingUnitKey / (31 * 12);
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
