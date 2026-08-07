using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();
int n = 100;

int Logarithmic(int n)
{
    stopwatch.Start();
    int k = 0;
    while (n > 0)
    {
        n /= 2;
        k++;
    }
    return k;
}

Logarithmic(n);
stopwatch.Stop();
Console.WriteLine($"Log: {stopwatch}ms");

int Linear(int n)
{
    stopwatch.Start();
    int k = 0;
    for (int i = 0; i < n; i++)
    {
        k++;
    }
    
    return k;
}

Linear(n);
stopwatch.Stop();
Console.WriteLine($"Linear: {stopwatch}ms");

int Quad(int n)
{
    stopwatch.Start();
    int k = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            k++;
        }
    }
    
    return k;
}

Quad(n);
stopwatch.Stop();
Console.WriteLine($"Quad: {stopwatch}ms");

int Exp(int n)
{ 
    stopwatch.Start();
    int k = 0;
    for (int i = 0; i < Math.Pow(2, n); i++)
    {
        k++;
    }
    
    return k;
}

Exp(n);
stopwatch.Stop();
Console.WriteLine($"Exp: {stopwatch}ms");