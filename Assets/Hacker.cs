using UnityEngine;

public class Hacker : MonoBehaviour
{

    //game config data
    string[] level1Passworods = { "book", "quiet", "shelf", "password", "library" };
    string[] level2Passworods = { "felony", "handcuffs", "prisoner", "detective" };

    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
    
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("W.O.P.R. © 1983");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") 
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    private void CheckPassword(string guess)
    {
        if (guess == password)
        {
            DisplayWinScreen();
            currentScreen = Screen.Win;

        }
        else
        {
            AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book!");
                Terminal.WriteLine(@"   
     _______
    /      /,
   /      //
  /______//
 (______(/
");
                break;
            case 2:
                Terminal.WriteLine("Jailbreak!");
                Terminal.WriteLine(@"
    _*_ ....iiooiioo
 __/_|_\__
[(o)_R_(o)]
");
                break;
            default:
                Debug.LogError("invalid win");
                break;
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();

        }  
        else if (input == "vanillabear")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congratulations, you're a l33t h4x0r!"); 
        }
        else
        {
            Terminal.WriteLine("SYNTAX ERROR LINE 1.");
        }
    }

    private void AskForPassword()
    {

        currentScreen = Screen.Password;

        // two fixed passwords, for each difficulty
        //check the password, ask again or say congrats

        Terminal.ClearScreen();
        GenerateRandomPassword();
        Terminal.WriteLine("Enter password, hint: " + password.Anagram());

    }

    private void GenerateRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passworods[Random.Range(0, level1Passworods.Length)];
                break;
            case 2:
                password = level2Passworods[Random.Range(0, level2Passworods.Length)];
                break;
            default:
                Debug.LogError("invalid level");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
