using System;

public enum AccountType
{
    Current,
    Savings,
    Deposit
}

public class BankAccount
{
    private static int idCounter = 1000;

    private int accountNumber;
    private double balance;
    private AccountType type;

    public static void IncrementCounter()
    {
        idCounter = idCounter + 1;
    }

    public void SetAccountData(double initialBalance, AccountType accountType)
    {
        IncrementCounter();
        accountNumber = idCounter;
        balance = initialBalance;
        type = accountType;
    }

    // Положить деньги на счет
    public void Deposit(double amount)
    {

            balance = balance + amount;
            Console.WriteLine("Счет " + accountNumber + " пополнен на " + amount + " руб.");
      
    }

    // Снять деньги со счета (с проверкой)
    public bool Withdraw(double amount)
    {
        // Проверяем, хватает ли денег на счете
        if (amount <= balance)
        {
            balance = balance - amount;
            Console.WriteLine("Со счета " + accountNumber + " успешно снято " + amount + " руб.");
            return true; // возвращаем true, так как снятие прошло успешно
        }
        else
        {
            Console.WriteLine("Ошибка на счете " + accountNumber + ": Недостаточно средств для снятия " + amount + " руб.!");
            return false; // возвращаем false, снятие невозможно
        }
    }

    public int GetAccountNumber()
    {
        return accountNumber;
    }

    public double GetBalance()
    {
        return balance;
    }

    public AccountType GetAccountType()
    {
        return type;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Номер счета: " + accountNumber);
        Console.WriteLine("Тип счета: " + type);
        Console.WriteLine("Текущий баланс: " + balance + " руб.");
        Console.WriteLine("-----------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем тестовый счет с начальным балансом 5000 рублей
        BankAccount myAcc = new BankAccount();
        myAcc.SetAccountData(5000.00, AccountType.Current);

        Console.WriteLine("Исходное состояние счета ");
        myAcc.PrintInfo();

        // Тестируем пополнение счета
        Console.WriteLine("Проверка пополнения");
        myAcc.Deposit(1500.00);
        Console.WriteLine("Баланс после пополнения: " + myAcc.GetBalance() + " руб.\n");

        // Тестируем успешное снятие денег
        Console.WriteLine("Проверка успешного снятия");
        myAcc.Withdraw(3000.00);
        Console.WriteLine("Баланс после снятия: " + myAcc.GetBalance() + " руб.\n");

        // Тестируем попытку снять больше, чем есть на балансе
        Console.WriteLine("Проверка снятия при нехватке средств");
        myAcc.Withdraw(10000.00); // Тут должна выскочить ошибка
        Console.WriteLine("Баланс остался прежним: " + myAcc.GetBalance() + " руб.\n");

        Console.ReadLine();
    }
}
