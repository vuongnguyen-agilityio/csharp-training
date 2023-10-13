using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DotNet.samples
{
    internal class Account
    {
        private readonly object balanceLock = new object();
        private decimal balance;

        public Account(decimal initialBalance) => balance = initialBalance;

        public decimal Debit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The debit amount cannot be negative.");
            }

            decimal appliedAmount = 0;
            lock (balanceLock)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    appliedAmount = amount;
                }
            }
            return appliedAmount;
        }

        public void Credit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The credit amount cannot be negative.");
            }

            lock (balanceLock)
            {
                balance += amount;
            }
        }

        public decimal GetBalance()
        {
            lock (balanceLock)
            {
                return balance;
            }
        }
    }

    public class LockStatementSample
    {
        public async Task RunTest()
        {
            Stopwatch s = Stopwatch.StartNew();
            var account = new Account(1000);
            var tasks = new Task[1000000];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => Update(account));
            }
            await Task.WhenAll(tasks);
            Console.WriteLine($"Account's balance is {account.GetBalance()}");
            Console.WriteLine($"Test file ran into: {s.Elapsed}");
        }

        static void Update(Account account)
        {
            decimal[] amounts = { 0, 2, -3, 6, -2, -1, 8, -5, 11, -6 };
            foreach (var amount in amounts)
            {
                if (amount >= 0)
                {
                    account.Credit(amount);
                }
                else
                {
                    account.Debit(Math.Abs(amount));
                }
            }
        }
    }
}
