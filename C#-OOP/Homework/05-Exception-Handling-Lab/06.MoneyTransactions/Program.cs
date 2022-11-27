namespace _06.MoneyTransactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = Console
                .ReadLine()
                .Split(',')
                .Select(x => x.Split('-'))
                .ToDictionary(x => int.Parse(x[0]), x => double.Parse(x[1]));

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                int accountNumber = int.Parse(cmdArgs[1]);
                double amount = double.Parse(cmdArgs[2]);

                try
                {
                    switch (action)
                    {
                        case "Deposit":
                            accounts[accountNumber] += amount;
                            break;
                        case "Withdraw":
                            if (accounts[accountNumber] < amount)
                                throw new InvalidOperationException("Insufficient balance!");

                            accounts[accountNumber] -= amount;
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                    
                    Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:F2}");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
