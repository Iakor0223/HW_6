using System;

// 1. АБСТРАКТНЫЙ КЛАСС (Родительский)
public abstract class Vehicle
{
    // Поля класса
    private string brand;
    private int speed;
    private double price;
    private string color;

    // СВОЙСТВА
    // 1 Свойство только для чтения (get)
    public string Brand
    {
        get { return brand; }
    }

    // 2 Свойство для чтения и записи (get/set)
    public int Speed
    {
        get { return speed; }
        set
        {
            if (value >= 0) speed = value;
        }
    }

    // 3 Свойство для чтения и записи цены
    public double Price
    {
        get { return price; }
        set { if (value >= 0) price = value; }
    }

    // 4 Свойство для чтения и записи цвета
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    // Конструктор базового класса
    public Vehicle(string vehicleBrand, int vehicleSpeed, double vehiclePrice, string vehicleColor)
    {
        brand = vehicleBrand;
        speed = vehicleSpeed;
        price = vehiclePrice;
        color = vehicleColor;
    }

    // МЕТОДЫ (5 методов в классе)
    // Метод 1: Абстрактный метод
    public abstract void Move();

    // Метод 2: Обычный метод сигнала
    public void Beep()
    {
        Console.WriteLine(brand + " издает звуковой сигнал!");
    }

    // Метод 3: Покраска транспорта
    public void Repaint(string newColor)
    {
        color = newColor;
        Console.WriteLine(brand + " перекрашен в " + newColor + " цвет.");
    }

    // Метод 4: Изменение цены со скидкой
    public void ApplyDiscount(double discountAmount)
    {
        price = price - discountAmount;
    }

    // Метод 5: Вывод базовой информации
    public void PrintBaseInfo()
    {
        Console.WriteLine("Марка: " + brand + ", Скорость: " + speed + " км/ч, Цена: " + price + " руб, Цвет: " + color);
    }
}

// 2. КЛАСС-НАСЛЕДНИК 1 (Машина)
public class Car : Vehicle
{
    private int fuelCapacity;
    private bool isEngineOn;

    // Свойства для Car (выполнение нормы по свойствам и методам)
    public int FuelCapacity { get { return fuelCapacity; } set { fuelCapacity = value; } }
    public bool IsEngineOn { get { return isEngineOn; } }

    // КОНСТРУКТОР 1 (Полный)
    public Car(string brand, int speed, double price, string color, int fuel)
        : base(brand, speed, price, color)
    {
        fuelCapacity = fuel;
        isEngineOn = false;
    }

    // КОНСТРУКТОР 2 (Упрощенный)
    public Car() : base("Лада", 0, 0, "Белый")
    {
        fuelCapacity = 50;
        isEngineOn = false;
    }

    // МЕТОДЫ
    // Метод 1: Реализация абстрактного метода движения
    public override void Move()
    {
        if (isEngineOn) Console.WriteLine("Машина " + Brand + " едет со скоростью " + Speed + " км/ч.");
        else Console.WriteLine("Ошибка: Сначала заведите мотор машины " + Brand + "!");
    }

    // Метод 2: Запуск двигателя
    public void StartEngine()
    {
        isEngineOn = true;
        Console.WriteLine("Двигатель машины " + Brand + " заведен.");
    }

    // Метод 3: Остановка двигателя
    public void StopEngine()
    {
        isEngineOn = false;
        Console.WriteLine("Двигатель машины " + Brand + " заглушен.");
    }

    // Метод 4: Заправка
    public void Refuel()
    {
        Console.WriteLine("Машина " + Brand + " заправлена на " + fuelCapacity + " литров.");
    }

    // Метод 5: Полный вывод информации
    public void ShowCarDetails()
    {
        PrintBaseInfo();
        Console.WriteLine("Объем бака: " + fuelCapacity + " л. Заведена: " + isEngineOn);
    }
}

// 3. КЛАСС-НАСЛЕДНИК 2 (Велосипед)
public class Bicycle : Vehicle
{
    private int gearCount;
    private bool hasBasket;

    public int GearCount { get { return gearCount; } set { gearCount = value; } }
    public bool HasBasket { get { return hasBasket; } set { hasBasket = value; } }

    // КОНСТРУКТОР 1 (Полный)
    public Bicycle(string brand, int speed, double price, string color, int gears, bool basket)
        : base(brand, speed, price, color)
    {
        gearCount = gears;
        hasBasket = basket;
    }

    // КОНСТРУКТОР 2 (Упрощенный)
    public Bicycle(string brand, double price) : base(brand, 15, price, "Красный")
    {
        gearCount = 1;
        hasBasket = false;
    }

    // МЕТОДЫ (5 методов)
    // Метод 1: Реализация абстрактного метода
    public override void Move()
    {
        Console.WriteLine("Велосипед " + Brand + " крутит педали со скоростью " + Speed + " км/ч.");
    }

    // Метод 2: Переключение передачи
    public void ChangeGear(int newGear)
    {
        Console.WriteLine("На велосипеде " + Brand + " включена " + newGear + " передача.");
    }

    // Метод 3: Звонок в колокольчик
    public void RingBell()
    {
        Console.WriteLine("Велосипед " + Brand + " звенит");
    }

    // Метод 4: Проверка багажника/корзины
    public void CheckBasket()
    {
        if (hasBasket) Console.WriteLine("В корзину велосипеда " + Brand + " можно положить вещи.");
        else Console.WriteLine("У велосипеда " + Brand + " нет корзины.");
    }

    // Метод 5: Вывод информации
    public void ShowBicycleDetails()
    {
        PrintBaseInfo();
        Console.WriteLine("Кол-во скоростей: " + gearCount + ", Наличие корзины: " + hasBasket);
        Console.WriteLine("---------------------------------------------");
    }
}

// 4. ДОПОЛНИТЕЛЬНЫЙ КЛАСС (Гараж / Агрегатор)
public class Garage
{
    private string address;
    private int capacity;

    public string Address { get { return address; } set { address = value; } }
    public int Capacity { get { return capacity; } set { capacity = value; } }

    public Garage(string garageAddress, int garageCapacity)
    {
        address = garageAddress;
        capacity = garageCapacity;
    }

    // МЕТОДЫ (5 методов для выполнения нормы 4-го класса)
    // Метод 1: Припарковать авто
    public void ParkCar(Car car)
    {
        Console.WriteLine("Машина " + car.Brand + " припаркована в гараж по адресу: " + address);
    }

    // Метод 2: Припарковать велосипед
    public void ParkBicycle(Bicycle bike)
    {
        Console.WriteLine("Велосипед " + bike.Brand + " поставлен в гараж.");
    }

    // Метод 3: Открыть ворота
    public void OpenDoors()
    {
        Console.WriteLine("Ворота гаража на " + capacity + " мест открыты.");
    }

    // Метод 4: Закрыть ворота
    public void CloseDoors()
    {
        Console.WriteLine("Ворота гаража закрыты.");
    }

    // Метод 5: Информация о гараже
    public void PrintGarageInfo()
    {
        Console.WriteLine("Гараж по адресу: " + address + " (Вместимость: " + capacity + " мест).");
    }
}

// ГЛАВНЫЙ КЛАСС ВЫПОЛНЕНИЯ
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ДЕМОНСТРАЦИЯ ПРИНЦИПОВ ООП ===\n");

        // 1 Создание объектов через разные конструкторы
        Car myCar = new Car("Lada Granta", 140, 900000, "Серый", 50); // Использован полный конструктор
        Car defaultCar = new Car();                                    // Использован дефолтный конструктор

        Bicycle myBike = new Bicycle("Stels", 25, 15000, "Зеленый", 21, true); // Полный конструктор
        Bicycle simpleBike = new Bicycle("Кама", 8000);                         // Упрощенный конструктор

        Garage myGarage = new Garage("ул. Опустошения, д. 1", 2);

        // 2 Демонстрация работы методов машин
        Console.WriteLine("--- Работа с машиной ---");
        myCar.ShowCarDetails();
        myCar.Move(); // Попытка поехать без мотора
        myCar.StartEngine();
        myCar.Move(); // Успешная поездка
        myCar.Repaint("Черный");
        myCar.ApplyDiscount(50000); // Сделали скидку
        myCar.ShowCarDetails(); // Смотрим изменения

        // 3 Демонстрация работы методов велосипедов
        Console.WriteLine("--- Работа с велосипедом ---");
        myBike.ShowBicycleDetails();
        myBike.Move();
        myBike.ChangeGear(5);
        myBike.RingBell();
        myBike.CheckBasket();
        Console.WriteLine();

        // 4 Демонстрация работы четвертого класса (Гараж)
        Console.WriteLine("--- Работа с гаражом ---");
        myGarage.PrintGarageInfo();
        myGarage.OpenDoors();
        myGarage.ParkCar(myCar);
        myGarage.ParkBicycle(myBike);
        myGarage.CloseDoors();

        Console.ReadLine();
    }
}
