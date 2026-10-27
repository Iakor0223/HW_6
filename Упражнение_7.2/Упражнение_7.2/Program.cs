using System;

//типы счетов
public enum AccountType
{
    Current,
    Savings,
    Deposit
}

// Класс банковского счета
public class BankAccount
{
    // Статическая переменная для хранения текущего ID
    private static int idCounter = 1000;

    // Закрытые поля объекта
    private int accountNumber;
    private double balance;
    private AccountType type;

    // Статический метод, который увеличивает переменную на 1
    public static void IncrementCounter()
    {
      idCounter = idCounter + 1;
    }

    // Метод заполнения данных
    public void SetAccountData(double initialBalance, AccountType accountType)
    {
        IncrementCounter();

        accountNumber = idCounter;
        balance = initialBalance;
        type = accountType;
    }

    // геттеры
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

    // Вывод информации
    public void PrintInfo()
    {
        Console.WriteLine("Номер счета: " + accountNumber);
        Console.WriteLine("Тип счета: " + type);
        Console.WriteLine("Баланс: " + balance);
        Console.WriteLine("-----------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount acc1 = new BankAccount();

        acc1.SetAccountData(5000.00, AccountType.Current);

        Console.WriteLine("Проверка автогенерации номеров");
        acc1.PrintInfo();

        Console.ReadLine();
    }
}
