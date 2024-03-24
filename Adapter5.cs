using System;

// Interfejs rejestrowania używany przez istniejący system
public interface ILogger
{
    void Log(string message);
    void LogError(string error);
    void LogWarning(string warning);
}

// Klasa implementująca interfejs ILogger, która używa nowej biblioteki rejestrowania
public class NewLogger : ILogger
{
    public void Log(string message)
    {
        // Logika zapisu wiadomości przy użyciu nowej biblioteki rejestrowania
        Console.WriteLine($"Logging message: {message}");
    }

    public void LogError(string error)
    {
        // Logika zapisu błędu przy użyciu nowej biblioteki rejestrowania
        Console.WriteLine($"Logging error: {error}");
    }

    public void LogWarning(string warning)
    {
        // Logika zapisu ostrzeżenia przy użyciu nowej biblioteki rejestrowania
        Console.WriteLine($"Logging warning: {warning}");
    }
}

// Adapter, który przekształca interfejs ILogger na interfejs używany przez istniejący system
public class LoggerAdapter : ILogger
{
    private readonly NewLogger newLogger;

    public LoggerAdapter()
    {
        this.newLogger = new NewLogger();
    }

    public void Log(string message)
    {
        // Wywołanie odpowiedniej metody nowej biblioteki rejestrowania
        newLogger.Log(message);
    }

    public void LogError(string error)
    {
        // Wywołanie odpowiedniej metody nowej biblioteki rejestrowania
        newLogger.LogError(error);
    }

    public void LogWarning(string warning)
    {
        // Wywołanie odpowiedniej metody nowej biblioteki rejestrowania
        newLogger.LogWarning(warning);
    }
}

// Przykładowe użycie adaptera w istniejącym systemie
public class ExistingSystem
{
    private readonly ILogger logger;

    public ExistingSystem(ILogger logger)
    {
        this.logger = logger;
    }

    public void DoSomething()
    {
        // Logowanie wiadomości
        logger.Log("Doing something...");

        // Symulacja błędu
        logger.LogError("An error occurred!");

        // Ostrzeżenie
        logger.LogWarning("This is a warning.");
    }
}

// Przykładowe użycie
class Program
{
    static void Main(string[] args)
    {
        // Tworzenie adaptera z nową biblioteką rejestrowania
        ILogger loggerAdapter = new LoggerAdapter();

        // Inicjalizacja istniejącego systemu z adapterem
        ExistingSystem system = new ExistingSystem(loggerAdapter);

        // Wywołanie metody w istniejącym systemie
        system.DoSomething();
    }
}
