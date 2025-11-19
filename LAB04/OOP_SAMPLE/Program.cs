namespace OOP_SAMPLE;
class Program
{
    static void Main(string[] args)
    {
        
        QuadraticEquation eq1 = new QuadraticEquation(1, -4, 4);
        eq1.PrintInfo();
        Console.WriteLine(eq1.GetRootsCount());
        QuadraticEquation eq2 = new QuadraticEquation(2, 4, -5);
        eq2.PrintInfo();
        Console.WriteLine(eq2.GetRootsCount());
        QuadraticEquation eq3 = new QuadraticEquation(1, 2, 3);
        eq3.PrintInfo();
        Console.WriteLine(eq3.GetRootsCount());
        Console.WriteLine("Get Roots Of Equation 1: ");
        foreach (double root in eq1.GetRootsCount())
        {
            Console.WriteLine($"Root = {root}");
        }
        Console.WriteLine("Get Roots Of Equation 2: ");
        foreach (double root in eq2.GetRootsCount())
        {
            Console.WriteLine($"Root = {root}");
        }
        Console.WriteLine("Get Roots Of Equation 3: ");
        foreach (double root in eq3.GetRootsCount())
        {
            Console.WriteLine($"Root = {root}");
        }

    }
}

