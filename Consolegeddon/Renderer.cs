using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Renderer
{
    public void Rect(char character, int x, int y, int width, int height)
    {
        int consoleTop = Console.CursorTop;
        int consoleLeft = Console.CursorLeft;
        int clampedWidth = width > Console.WindowWidth ? Console.WindowWidth : width;
        for (; height > 0;)
        {
            --height;
            Console.SetCursorPosition(x, y + height);
            Console.Write(new String(character, width));
        }
        Console.SetCursorPosition(consoleLeft, consoleTop);
    }

    public void Text(string message, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(message);
    }

    public void Text(char character, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(character);
    }

    public void Circle(char character, float x, float y, float radius, float heightFactor)
    {

        float a = radius * 2;
        float b = radius;

        for (int i = 0; i < radius * 4 + 0.5f; i++)
        {
            for(int j = 0; j < radius * 2 + 0.5f; j++)
            {
                var circleX = i - a;
                var circleY = j - b;

                if ( (circleX * circleX) / (a * a) + (circleY * circleY) / (b * b) <= 1) {
                    Text(character, (int)MathF.Round(circleX + x), (int)MathF.Round(circleY + y));
                } else {
                    Text(' ', (int)MathF.Round(circleX + x), (int)MathF.Round(circleY + y));
                }
            }
        }
    }
}
