using System.Text;
using RobotInvaders;

namespace RobotInvaders.Tests;

[TestFixture]
public class ProgramTests
{
    [TestCase]
    public void Main_CorrectlyCalculatesScore()
    {
        using (ConsoleOutput consoleOutput = new ConsoleOutput())
        {
            Program.Main(null);

            string[] consoleLines = consoleOutput.GetOuput().Split(Environment.NewLine);
            int scoreIndex = Array.IndexOf(consoleLines, "YOU SCORED");

            int score = int.Parse(consoleLines[scoreIndex + 1].Split('/')[0].Trim().Split(' ')[2]);
            int numberOfTurns = int.Parse(consoleLines[scoreIndex + 1].Split('/')[1]);

            Assert.AreEqual(numberOfTurns, 25, "Number of turns should be 25");
            Assert.IsTrue(score >= 0 && score <= 25, "Score should be between 0 and 25");
        }
    }

    [TestCase]
    public void Main_CorrectlyHandlesKeyPresses()
    {
        using (var consoleInput = new ConsoleInput())
        using (var consoleOutput = new ConsoleOutput())
        {
            consoleInput.Add("A");
            Program.Main(null);

            string[] consoleLines = consoleOutput.GetOuput().Split(Environment.NewLine);
            int scoreIndex = Array.IndexOf(consoleLines, "YOU SCORED");

            int score = int.Parse(consoleLines[scoreIndex + 1].Split('/')[0].Trim().Split(' ')[2]);
            int numberOfTurns = int.Parse(consoleLines[scoreIndex + 1].Split('/')[1]);

            Assert.AreEqual(numberOfTurns, 25, "Number of turns should be 25");
            Assert.IsTrue(score >= 0 && score <= 25, "Score should be between 0 and 25");
            CollectionAssert.Contains(consoleLines, "A HIT", "Should have at least one HIT");
        }
    }

    [TestCase]
    public void ClearKeyPresses_ClearsKeyboardBuffer()
    {
        using (var consoleInput = new ConsoleInput())
        {
            consoleInput.Add("A");
            Program.ClearKeyPresses();

            Assert.IsFalse(Console.KeyAvailable, "Keyboard buffer should be cleared");
        }
    }
}



public class ConsoleInput
{
private readonly StringReader _input;

public ConsoleInput()
{
    _input = new StringReader(string.Empty);
    Console.SetIn(_input);
}

public void Add(string input)
{
    _input.Close();
    _input = new StringReader(input);
    Console.SetIn(_input);
}
}

public class ConsoleOutput
{
private readonly StringBuilder _output = new StringBuilder();
private readonly StringWriter _writer;

public ConsoleOutput()
{
    _writer = new StringWriter(_output);
    Console.SetOut(_writer);
}

public string GetOuput()
{
    return _output.ToString();
}
}

