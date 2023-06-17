using System.Globalization;
class Program
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
        string[] temp = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "data.cvs"));
        List<double> x = new List<double>();
        List<double> y = new List<double>();
        for (int i = 1; i < temp.Length; i++)
        {
            if (temp[i] == "")
            {
                continue;
            }
            string[] temp2 = temp[i].Split(',');
            x.Add(double.Parse(temp2[0]));
            y.Add(double.Parse(temp2[1]));
        }
        double sumX = SumX(x);
        double sumY = SumY(y);
        double sumXY = SumXY(x, y);
        double sumXX = SumXX(x);
        double m = M(x.Count(), sumX, sumY, sumXY, sumXX);
        double b = B(x.Count(), sumX, sumY, m);
        Console.WriteLine(Predict(m, b, 56));
    }

    public static double Predict(double m, double b, double x)
    {
        double pred = m * x + b;
        return pred;
    }

    static double M(int n, double x, double y, double xy, double xx)
    {
        double m = (n * xy - x * y) / (n * xx - x * x);
        return m;
    }

    static double B(int n, double x, double y, double m)
    {
        double b = (y - m * x) / n;
        return b;
    }

    static double SumX(List<double> x)
    {
        double sum = 0.0;
        for (int i = 0; i < x.Count(); i++)
        {
            sum += x[i];
        }
        return sum;
    }
    static double SumY(List<double> y)
    {
        double sum = 0.0;
        for (int i = 0; i < y.Count(); i++)
        {
            sum += y[i];
        }
        return sum;
    }
    static double SumXY(List<double> x, List<double> y)
    {
        double sum = 0.0;
        for (int i = 0; i < y.Count(); i++)
        {
            sum += x[i] * y[i];
        }
        return sum;
    }
    static double SumXX(List<double> x)
    {
        double sum = 0.0;
        for (int i = 0; i < x.Count(); i++)
        {
            sum += x[i] * x[i];
        }
        return sum;
    }
}