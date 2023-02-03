namespace RobotInvaders;
static public class Program
{
    static public void Main(string[] args)
    {
        Console.Title = "ROBOT INVADERS";
        Random random = new();

        int numberOfTurns = 25;
        int score = 0;
        for(var turnsTaken = 0; turnsTaken < numberOfTurns; turnsTaken++)
        {

            Thread.Sleep(Convert.ToInt32(random.NextDouble() * 30 + 20) * 50);
            var xAxis = Convert.ToInt32(random.NextDouble() * 20);
            var yAxis = Convert.ToInt32(random.NextDouble() * 15);
            var p = Convert.ToChar(random.Next(65, 90));
            Console.Clear();
            for(int j = 0; j < yAxis; j++) 
            {
                Console.WriteLine();
            }
            string display = "" + p;
            Console.WriteLine(display.PadLeft(xAxis));
            ClearKeyPresses();
            Thread.Sleep(2000);
            if (Console.KeyAvailable)
            {
                var keyPressed = Console.ReadKey(true).KeyChar.ToString();
                if (keyPressed.ToUpper() == p.ToString().ToUpper())
                {
                    Console.WriteLine("A HIT");
                    score++;
                }
                else 
                {
                    Console.WriteLine("MISS");
                }
            }
            else
            {
                Console.WriteLine("MISS");
            }
        }
        Console.Clear();
        Console.WriteLine($"YOU SCORED {score}/{numberOfTurns}");
    }

    /// <summary>
    /// Will clear keyboard buffer to prevent too many keystrokes affecting next input
    /// </summary>
    static void ClearKeyPresses()
    {
        while(Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }
}