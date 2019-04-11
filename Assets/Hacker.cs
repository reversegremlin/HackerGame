using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

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

    }

    private void RunMainMenu(string input)
    {

        if (input == "1")
        {
            level = 1;
            StartGame();

        }
        else if (input == "2")
        {
            level = 2;
            StartGame();

        }
        else if (input == "vanillabear")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("root access granted...");
        }
        else
        {
            Terminal.WriteLine("SYNTAX ERROR LINE 1.");
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
