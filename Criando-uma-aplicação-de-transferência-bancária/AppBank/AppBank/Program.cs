/*
 * Created by: Maykon Ferreira
 * Manaus, AM - Brazil
 * 21/09/2021
 * Linkedin: https://www.linkedin.com/in/maykon-ferreira/
 * GitHub: https://github.com/MaykonFerrero
 * 
 * This project it's a AppBank that you can to deposit, transfer, withdraw money in an account that you created when you run this code.
 * The apllication don't use a Db, the accounts is onlu saved while the program is running.
 * Thanks Digital Innovation One for this course!
 * 
 * 
 */







using System;
using System.Collections.Generic;

namespace AppBank
{
    class Program
    {

        static List<Account> listAccount = new List<Account>();


        static void Main(string[] args)
        {
            string useroption = UserOptions();

            while (useroption != "X")
            {
                switch (useroption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        WithdrawMoney();
                        break;
                    case "4":
                        DepositMoney();
                        break;
                    case "5":
                        TransferMoney();
                        break;
                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }

                useroption = UserOptions();
            }
            Console.WriteLine("Thank you!");
            Console.ReadLine();
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert new Account");
            Console.WriteLine("Type 1 for Natural Person or 2 for Legal Person");
            int accountType = int.Parse(Console.ReadLine());

            Console.WriteLine("Client's name:");
            string accountName = Console.ReadLine();

            Console.WriteLine("Opening balance:");
            double accountBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Credit:");
            double accountCredit = double.Parse(Console.ReadLine());


            //creating a new object
            Account newAccount = new Account(account: (AccountType)accountType,   //atributes (you can find in Account.cs)
                                              balance: accountBalance,
                                              credit: accountCredit,
                                              name: accountName);

            listAccount.Add(newAccount);
        }

        private static void ListAccounts()
        {
            Console.WriteLine("List Accounts");

            if (listAccount.Count == 0)
            {
                Console.WriteLine("No one count created");
                return;
            }
            for (int i =0; i < listAccount.Count; i++)
            {
                Account account = listAccount[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void WithdrawMoney()
        {
         
            Console.WriteLine("Type the number account:");
            int idAccount = int.Parse(Console.ReadLine());

            Console.Write("How much would you like to take out?");
            double withdrawValue = double.Parse(Console.ReadLine());

            listAccount[idAccount].Withdraw(withdrawValue);
        }

        private static void DepositMoney()
        {

            Console.WriteLine("Type the number account:");
            int idAccount = int.Parse(Console.ReadLine());

            Console.Write("How much would you like to take in?");
            double depositValue = double.Parse(Console.ReadLine());

            listAccount[idAccount].Withdraw(depositValue);
        }

        private static void TransferMoney()
        {

            Console.WriteLine("Type the origin account number:");
            int idAccountOrigin = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the destiny account number:");
            int idAccountDestiny = int.Parse(Console.ReadLine());

            Console.Write("How much would you like to transfer?");
            double transferValue = double.Parse(Console.ReadLine());

            listAccount[idAccountOrigin].Tranfer(transferValue,listAccount[idAccountDestiny]);
        }

        private static string UserOptions()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Welcome to AppBAnk");
            Console.WriteLine("What do you want to do?");

            Console.WriteLine("1 - List accounts");
            Console.WriteLine("2 - Insert new account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("6 - Clear Screen");
            Console.WriteLine("X - Out");
            Console.WriteLine();

            string useroption = Console.ReadLine().ToUpper();
            Console.WriteLine("---------------------------------------------");

            return useroption;
        }



    }
}
