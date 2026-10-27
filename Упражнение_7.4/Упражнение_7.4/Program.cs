using System;

public class Building
{
    // СТАТИЧЕСКОЕ ПОЛЕ для генерации уникального номера здания
    private static int lastBuildingId = 0;

    // Закрытые поля (инкапсуляция)
    private int buildingId;         // уникальный номер здания
    private double height;          // высота здания (в метрах)
    private int floors;             // этажность
    private int apartments;         // количество квартир
    private int entrances;          // количество подъездов

    // Статический метод, который увеличивает значение статического поля
    public static void IncrementCounter()
    {
        lastBuildingId = lastBuildingId + 1;
    }

    // Метод для заполнения полей
    public void SetBuildingData(double buildingHeight, int buildingFloors, int totalApartments, int totalEntrances)
    {
        IncrementCounter(); // увеличиваем глобальный счетчик
        buildingId = lastBuildingId; // присваиваем текущему зданию новый уникальный номер

        height = buildingHeight;
        floors = buildingFloors;
        apartments = totalApartments;
        entrances = totalEntrances;
    }

    // Методы для получения значений полей для печати (Getters)
    public int GetBuildingId() { return buildingId; }
    public double GetHeight() { return height; }
    public int GetFloors() { return floors; }
    public int GetApartments() { return apartments; }
    public int GetEntrances() { return entrances; }

    // Метод 1: Вычисление высоты одного этажа
    public double CalculateFloorHeight()
    {
        if (floors > 0)
        {
            return height / floors;
        }
        return 0;
    }

    // Метод 2: Вычисление количества квартир в одном подъезде
    public int CalculateApartmentsPerEntrance()
    {
        if (entrances > 0)
        {
            return apartments / entrances;
        }
        return 0;
    }

    // Метод 3: Вычисление количества квартир на одном этаже
    public int CalculateApartmentsPerFloor()
    {
        if (floors > 0)
        {
            return apartments / floors;
        }
        return 0;
    }

    // Метод для вывода информации на печать
    public void PrintInfo()
    {
        Console.WriteLine("--- Информация о здании №" + buildingId + " ---");
        Console.WriteLine("Высота здания: " + height + " м.");
        Console.WriteLine("Количество этажей: " + floors);
        Console.WriteLine("Всего квартир: " + apartments);
        Console.WriteLine("Количество подъездов: " + entrances);
        Console.WriteLine("Высота одного этажа: " + CalculateFloorHeight() + " м.");
        Console.WriteLine("Квартир в подъезде: " + CalculateApartmentsPerEntrance());
        Console.WriteLine("Квартир на одном этаже (в среднем): " + CalculateApartmentsPerFloor());
        Console.WriteLine("------------------------------------------\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем первый объект здания
        Building b1 = new Building();
        b1.SetBuildingData(30.5, 9, 72, 2); // высота 30.5м, 9 этажей, 72 квартиры, 2 подъезда

        // Создаем второй объект здания
        Building b2 = new Building();
        b2.SetBuildingData(50.0, 16, 128, 2); // высота 50м, 16 этажей, 128 квартир, 2 подъезда

        // Выводим результаты на печать
        Console.WriteLine("=== Проверка работы класса Building ===\n");
        b1.PrintInfo();
        b2.PrintInfo();

        Console.ReadLine();
    }
}
