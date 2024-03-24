using System;

// Interfejs oczekiwany przez funkcję
interface IShape
{
    float getArea();
}

// Klasa Square reprezentująca kwadrat
class Square
{
    private float side;

    public Square(float side)
    {
        this.side = side;
    }

    public float calculateArea()
    {
        return side * side;
    }
}

// Klasa adaptera dostosowująca Square do interfejsu IShape
class Adapter : IShape
{
    private Square square;

    public Adapter(Square square)
    {
        this.square = square;
    }

    public float getArea()
    {
        return square.calculateArea();
    }
}

// Funkcja przyjmująca obiekt implementujący IShape
class Program
{
    static void Main(string[] args)
    {
        // Użycie adaptera
        Square square = new Square(5);
        Adapter adapter = new Adapter(square);
        Function(adapter);
    }

    static void Function(IShape shape)
    {
        float area = shape.getArea();
        Console.WriteLine("Obszar: " + area);
        // Do something with area
    }
}
