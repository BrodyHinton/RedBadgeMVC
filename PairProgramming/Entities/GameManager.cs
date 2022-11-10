using static System.Console;

public class GameManager
{
    private bool isRunning = true;
    private Player player = new Player();
    private Suspect guiltyPerson;
    public void Run()
    {
        Seed();
        RunApplication();
    }

    private void RunApplication()
    {

        while (isRunning)
        {
            Clear();
            WriteLine("== Welcome to the Game of Clue ==");
            WriteLine(guiltyPerson.Name);
            PressAnyKey();
            StartGame();
            if (player.IsDead)
            {
                isRunning = PlayerDeath();
            }
            else
            {
                isRunning = YouWon();
            }
        }
    }

    private bool PlayerDeath()
    {
        WriteLine("You Died!");
        PressAnyKey();
        return false;
    }

    private void PressAnyKey()
    {
        WriteLine("Press any key to continue.");
        ReadKey();
    }

    private void StartGame()
    {
        // Clear();
        while (player.IsDead == false)
        {
            Clear();
            WriteLine("Who did it? \n" +
                  "Please type the full name.\n" +
                  "1. Miss Scarlet\n" +
                  "2. Mrs. White\n" +
                  "3. Mrs. Peacok\n" +
                  "4. Professor Plum\n" +
                  "5. Mr. Green\n" +
                  "6. Colonel Mustard\n" +
                  "7. Exit Game\n");

            string userInput = ReadLine();


            if (guiltyPerson.Name.ToLower() == userInput.ToLower())
            {
                break;
            }
            else
            {
                Clear();
                player.Lives--;
                WriteLine($"Sorry, Wrong Selection. Player Lives: {player.Lives}");
                ReadKey();
            }

        }

        ReadKey();
    }

    private bool YouWon()
    {
        WriteLine("Congrats!");
        PressAnyKey();
        return false;
    }

    private void Seed()
    {
        Suspect scarlet = new Suspect("Miss Scarlet", "Mysterious Beautiful Woman");
        Suspect white = new Suspect("Mrs. White", " Older Woman, must be a maid.");
        Suspect peacock = new Suspect("Mrs. Peacok", " Stylish woman, furs are her best friend.");
        Suspect plum = new Suspect("Professor Plum", "Old Nurdy Guy.");
        Suspect green = new Suspect("Mr. Green.", "Upright Middle Aged Man.");
        Suspect mustard = new Suspect("Colonel Mustard", "Old guy, looks like an old war veterian.");

        List<Suspect> suspects = new List<Suspect>()
        {
            scarlet,
            white,
            peacock,
            plum,
            green,
            mustard
        };

        guiltyPerson = GameUtility.GetRandomVillain(suspects);
    }
}
