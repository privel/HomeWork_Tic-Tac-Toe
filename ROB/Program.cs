using System;
using System.Drawing;
using Circle;
using Rectangle;

public class Program
{
    public static void Main(string[] args)

    {

        RectangleM rec = new RectangleM(); 


        int ans; 
        Console.WriteLine("1 - rectangle");
        Console.WriteLine("2 - square");
        Console.WriteLine("3 - circle");
        Console.WriteLine("0 - exit");

        ans = Convert.ToInt16( Console.ReadLine());

        switch (ans)
        {
            case 1:
                rec.ifRectangle();
                break;
        }


    }
}