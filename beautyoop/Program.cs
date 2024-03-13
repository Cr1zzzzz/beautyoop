using System;
using System.Collections.Generic;

class BeautySalon
{
    private Dictionary<string, List<string>> masters; // Ключ - ім'я майстра, значення - список процедур, які він виконує
    private Dictionary<string, string> clients; // Ключ - ім'я клієнта, значення - ім'я майстра

    public BeautySalon()
    {
        masters = new Dictionary<string, List<string>>();
        clients = new Dictionary<string, string>();
    }

    public void AddMaster(string masterName, List<string> procedures)
    {
        masters.Add(masterName, procedures);
    }

    public void BookProcedure(string clientName, string masterName, string procedure)
    {
        if (!masters.ContainsKey(masterName))
        {
            throw new ArgumentException($"Майстра з ім'ям {masterName} не знайдено.");
        }

        if (!masters[masterName].Contains(procedure))
        {
            throw new ArgumentException($"Майстер {masterName} не виконує процедуру {procedure}.");
        }

        if (clients.ContainsKey(clientName))
        {
            throw new ArgumentException($"Клієнт {clientName} вже записаний до майстра {clients[clientName]}.");
        }

        clients.Add(clientName, masterName);
        Console.WriteLine($"Клієнт {clientName} був записаний до майстра {masterName} на процедуру {procedure}.");
    }

    public void PrintLog()
    {
        Console.WriteLine("Лог подій:");
        foreach (var client in clients)
        {
            Console.WriteLine($"Клієнт {client.Key} записаний до майстра {client.Value}.");
        }
    }
}

class Program
{
    static void Main()
    {
        BeautySalon salon = new BeautySalon();

        // Додавання майстрів та їхніх процедур
        salon.AddMaster("Анна", new List<string> { "Манікюр", "Педикюр" });
        salon.AddMaster("Вікторія", new List<string> { "Стрижка", "Фарбування" });

        // Запис клієнтів до майстрів
        try
        {
            salon.BookProcedure("Ірина", "Анна", "Манікюр");
            salon.BookProcedure("Марина", "Вікторія", "Стрижка");
            salon.BookProcedure("Олена", "Анна", "Педикюр");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Вивід логу подій
        salon.PrintLog();
    }
}
