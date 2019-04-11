using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    //game config data
    string[] level1Passworods = { "book", "quiet", "self", "password" };
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
        if (level == 1)
        {
            if (guess == password)
            {
                Terminal.WriteLine("Congratulations, you're a l33t h4x0r!");
                currentScreen = Screen.Win;

            }
            else
            {
                Terminal.WriteLine("Try again...");
            }
        } 
        else if (level == 2)
        {
            if (guess == password)
            {
                Terminal.WriteLine("Congratulations, you're a l33t h4x0r!");
                currentScreen = Screen.Win;

            }
            else
            {
                Terminal.WriteLine("Try again...");
            }
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();


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

    private void StartGame()
    {

        currentScreen = Screen.Password;

        // two fixed passwords, for each difficulty
        //check the password, ask again or say congrats
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                password = level1Passworods[0];
                break;
            case 2:
                password = level2Passworods[0];
                break;
            default:
                Debug.LogError("invalid level");
                break;
        }

        Terminal.WriteLine("Please enter password: ");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
