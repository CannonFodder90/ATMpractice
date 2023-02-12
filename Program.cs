using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ATMpractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool checking = false;
            bool savings = false;
            bool acctLoop = true;
            decimal savBalance = 1000m;
            decimal chkBalance = 1000000m;

            //totally unnecessary ascii art...
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("__________     ________      __________ \r\n\\______   \\    \\_____  \\     \\______   \\\r\n |    |  _/     /   |   \\     |    |  _/\r\n |    |   \\    /    |    \\    |    |   \\\r\n |______  / /\\ \\_______  / /\\ |______  /\r\n        \\/  \\/         \\/  \\/        \\/ ");
            Console.WriteLine("---------------------------------------");
            
            //welcome script, stores name of client            
            Console.WriteLine("Welcome to Bank-o-Brian. Please enter your name to access your accout;");
            string clientName = Console.ReadLine();

            //While loop to contain to account selection
            top:
            while (acctLoop == true)
            {
                Console.WriteLine("\nWelcome " + clientName + ", what account are you accessing today?\n(checking/savings/exit)");
                string acctSelect = Console.ReadLine();
                string acctSelectLwr = acctSelect.ToLower();

                //Switch checks for account type: checking, saving, or exit
                switch (acctSelectLwr)
                {   //checking acct case
                    case "checking":
                        Console.WriteLine("\nYou have chosen checking. Is this correct? (y/n)");
                        string chkConfirm = Console.ReadLine();
                        string chkConfirmLwr = chkConfirm.ToLower();
                        if (chkConfirmLwr == "y")
                        {
                            acctLoop = false;
                            checking = true;
                            savings = false;
                            break;

                        }
                        else if (chkConfirm == "n")
                        {
                            goto top;
                        }
                        else
                        {
                            Console.WriteLine("\nThis is not a valid input.");
                            chkConfirm = ""; 
                            continue;
                        }

                    //savings acct case
                    case "savings":
                        Console.WriteLine("\nYou have chosen savings Is this correct? (y/n)");
                        string savConfirm = Console.ReadLine();
                        string savConfirmLwr = savConfirm.ToLower();
                        if (savConfirmLwr == "y")
                        {
                            acctLoop = false;
                            checking = false;
                            savings = true;
                            break;
                        }
                        else if (savConfirmLwr == "n")
                        {
                            goto top;
                        }
                        else
                        {
                            Console.WriteLine("\nThis is not a valid input");
                            savConfirm = "";
                            continue;
                        }

                    //Exit & confirm case
                    case "exit":
                        Console.WriteLine("\nDo you wish to exit? (y/n)");
                        string exConfirm = Console.ReadLine();
                        string exConfirmLwr = exConfirm.ToLower();
                        if (exConfirmLwr == "y")
                        {
                            Console.WriteLine("Goodbye " + clientName + ".");
                            Console.WriteLine("Press any key to exit");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else if (exConfirmLwr == "n")
                        {
                            continue;
                        }
                        else
                            Console.WriteLine("\nThis is not a valid input");
                        exConfirmLwr = "";
                        continue;

                    default:
                        Console.WriteLine("\nThat is not a valid selection");
                        chkConfirm = "";
                        continue;
                }                
            }
            //loop break, variables to send user to different loop for account types
            if (checking == true && savings == false)
            {
                goto checking;
            }
            else if (checking == false && savings == true)
            {
                goto savings;
            }
            else //this should never occur
            {
                Console.WriteLine("you done fucked up now");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
                Environment.Exit(0);
            }

        //Checking Acct loop for check, withdraw, deposit, exit  - uses goto and labels
        checking:
            while (checking == true)
            {   
                Console.WriteLine("\n-----You have chosen your checking account-----.\nWould you like to check your balance, make a deposit, withdraw, or exit?");
                Console.WriteLine("(check/deposit/withdraw/exit)");
                string actionSelect = Console.ReadLine();
                string actionSelectLwr = actionSelect.ToLower();

                //switch to check for "check, deposit, withdraw, or exit"
                switch (actionSelectLwr)
                {   //check acct case
                    case "check":
                        Console.WriteLine("\nYour current balance is $" + chkBalance + ".");
                        break;
                    //deposit
                    case "deposit":
                        Console.WriteLine("\nHow much would you like to deposit?");
                        decimal depositAmt = Convert.ToDecimal(Console.ReadLine());
                        chkBalance = chkBalance + depositAmt;
                        Console.WriteLine("Your new balance is now: $" + chkBalance);
                        break;
                    //withdraw
                    case "withdraw":
                        Console.WriteLine("\nHow much would you like to withdraw?");
                        decimal withdrawAmt = Convert.ToDecimal(Console.ReadLine());
                        chkBalance = chkBalance - withdrawAmt;
                        Console.WriteLine("Your new balance is now: $" + chkBalance);
                        break;
                    //exit
                    case "exit":
                        Console.WriteLine("\nDo you wish to exit? (y/n)");
                        string exConfirm = Console.ReadLine();
                        string exConfirmLwr = exConfirm.ToLower();
                        if (exConfirmLwr == "y")
                        {
                            Console.WriteLine("Goodbye " + clientName + ".");
                            Console.WriteLine("Press any key to exit");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else if (exConfirmLwr == "n")
                        {
                            break;
                        }
                        else
                            Console.WriteLine("This is not a valid input");
                        exConfirm = "";
                        continue;
                }
            }

        //Savings Acct loop for check, withdraw, deposit, exit  - use goto and labels
        savings:
            while (savings == true)
            {
                Console.WriteLine("\n-----You have chosen your savings account.-----\nWould you like to check your balance, make a deposit, withdraw, or exit?");
                Console.WriteLine("(check/deposit/withdraw/exit)");
                string actionSelect = Console.ReadLine();
                string actionSelectLwr = actionSelect.ToLower();

                //switch to check for "check, deposit, withdraw, or exit"
                switch (actionSelectLwr)
                {   //check
                    case "check":
                        Console.WriteLine("\nYour current balance is $" + savBalance + ".");
                        break;
                    //deposit
                    case "deposit":
                        Console.WriteLine("\nHow much would you like to deposit?");
                        decimal depositAmt = Convert.ToDecimal(Console.ReadLine());
                        savBalance = savBalance + depositAmt;
                        Console.WriteLine("Your new balance is now: $" + savBalance);
                        goto savings;
                    //withdraw
                    case "withdraw":
                        Console.WriteLine("\nHow much would you like to withdraw?");
                        decimal withdrawAmt = Convert.ToDecimal(Console.ReadLine());
                        savBalance = savBalance - withdrawAmt;
                        Console.WriteLine("Your new balance is now: $" + savBalance);
                        goto savings;
                    //exit
                    case "exit":
                        Console.WriteLine("\nDo you wish to exit? (y/n)");
                        string exConfirm = Console.ReadLine();
                        string exConfirmLwr = exConfirm.ToLower();
                        if (exConfirmLwr == "y")
                        {
                            Console.WriteLine("Goodbye " + clientName + ".");
                            Console.WriteLine("Press any key to exit");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else if (exConfirmLwr == "n")
                        {
                            break;
                        }
                        else
                            Console.WriteLine("This is not a valid input");
                        exConfirm = "";
                        continue;
                }
            }
        }
    }
}