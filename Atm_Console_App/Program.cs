using System;
using System.Collections.Generic;
using System.Linq;

namespace Atm_Console_App
{
    class Program
    {
        public class CardHolder
        {
            string cardNumber;
            string firstName;
            string lastName;
            int pin;
            double balance;

            enum Options
            {
                deposit, 
                withdraw,
                balance
            }

            public CardHolder(string cardNumber, string firstName, string lastName, int pin, double balance)
            {
                this.cardNumber = cardNumber;
                this.firstName = firstName;
                this.lastName = lastName;
                this.pin = pin;
                this.balance = balance;
            }

            public string getCardNumber()
            {
                return cardNumber;
            }

            public string getFirstName()
            {
                return firstName;
            }

            public string getLastName()
            {
                return lastName;
            }

            public int getPin()
            {
                return pin;
            }

            public double getBalance()
            {
                return balance;
            }

            public void setCardNumber(string newCardNumber)
            {
                cardNumber = newCardNumber;
            }

            public void setFirstName(string newFirstName)
            {
                firstName = newFirstName;
            }

            public void setLastName(string newLastName)
            {
                lastName = newLastName;
            }

            
            public void setPin(int newPin)
            {
                pin = newPin;
            }

            public void setBalance(double newBalance)
            {
                balance = newBalance;
            }
        }

        
        static void Main(string[] args)
        {
            void PrintOptions()
            {
                Console.WriteLine("Please choose one option");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void Deposit(CardHolder currentUser)
            {
                Console.WriteLine("How much $$ do you like deposit: ");
                double deposit = Convert.ToDouble(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("Thank you for you $$. Your new balance is " + currentUser.getBalance());
            }
            void WithDraw(CardHolder currentUSer)
            {
                Console.WriteLine("How much $$ would you like take withdraw: ");
                double withdrawal = Convert.ToDouble(Console.ReadLine());
                //Check if the user has enough money
                if (currentUSer.getBalance() < withdrawal)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    currentUSer.setBalance(currentUSer.getBalance() - withdrawal);
                    Console.WriteLine("You re good to go. Thank you");
                }
            }

            void Balance(CardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
            }

            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder("19850318", "Sandor", "Krakoczki",  1985, 2018.512));
            cardHolders.Add(new CardHolder("20180318", "Sophie", "Krakoczki",  2018, 20018));
            cardHolders.Add(new CardHolder("19870630", "Anett", "Szalai",  1987, 14984));
            cardHolders.Add(new CardHolder("19831001", "Gergo", "Bize",  1983, 7900));
            cardHolders.Add(new CardHolder("19473454",  "John", "Doe",  1947, 4));

            Console.WriteLine("Welcome to simple ATM");
            Console.WriteLine("Please insert your credit card");
            string debitCardNum = "";
            CardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.getCardNumber() == debitCardNum);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Card not recognized. Please try it again");
                    }
                }
                catch 
                {
                    Console.WriteLine("Card not recognized. Please try it again");
                }

            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;

            while (true)
            {
                try
                {
                    userPin = Convert.ToInt32(Console.ReadLine());
                    if(currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect pin. Please try it again");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect pin. Please try it again");
                }

            }
            Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
            int option = 0;
            do
            {
                PrintOptions();
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                switch (option)
                {
                    case 1:
                        Deposit(currentUser);
                        break;
                    case 2:
                        WithDraw(currentUser);
                        break;
                    case 3:
                        Balance(currentUser);
                            break;
                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }

            } while (option != 4);
            Console.WriteLine("Thank you");

        }
    }
}
