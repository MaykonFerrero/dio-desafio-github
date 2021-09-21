using System;
using System.Collections.Generic;
using System.Text;

namespace AppBank
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }


        public Account(AccountType account, double balance, double credit, string name) //constructor
        {
            this.AccountType = account;                                              //atributes
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;

        }

        public bool Withdraw(double withdrawValue)
        {
            //balance validation
            if(this.Balance - withdrawValue < (this.Credit * -1))
            {
                Console.WriteLine("Balance is not enought :,(");
                return false;
            }
            this.Balance -= withdrawValue;
          
            Console.WriteLine("withdraw aproved :)");
            Console.WriteLine("{0} your balance is : R${0}",this.Name, this.Balance);
            
            return true;

        }

        public void Deposit(double depositValue)
        {
            
            this.Balance += depositValue; ;
            
            Console.WriteLine("Deposit done :)");
            Console.WriteLine("{0} your balance is : R${0}", this.Name, this.Balance);
        }

        public void Tranfer(double TransferValue, Account destineAccount)
        {
            //validação de balance
            if (this.Withdraw(TransferValue)) {

                destineAccount.Deposit(TransferValue);
            }
        }

        public override string ToString()
        {
            string sreturn = "";
            sreturn += "AccountType:" + this.AccountType + "|";
            sreturn += "Name:" + this.Name + "|";
            sreturn += "Balance:" + this.Balance + "|";
            sreturn += "Credit:" + this.Credit + "|";
            return sreturn;
        }




    }
}
