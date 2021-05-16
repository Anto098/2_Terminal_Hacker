using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    // Game configuration data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "books", "aisle","self", "password", "font", "borrow"};
    string[] level2Passwords = { "police", "station", "bank", "money", "cash"};
    string[] level3Passwords = { "nogatneP", "FBI", "CIA", "President", "White House" };
    string password;

    // Game State
    string level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Use this for initialization
    void Start () {
        string greeting = "Hello Antonin";
        ShowMainMenu(greeting);
    }

    void ShowMainMenu(string greeting) {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What do you want to hack?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type 'Easy' for the Petro Station");
        Terminal.WriteLine("Type 'Medium' for the City Bank");
        Terminal.WriteLine("Type 'Hard' for The Pentagon");

    }

    void OnUserInput (string input) {
        if (input == "menu")
        {
            ShowMainMenu("Hello Antonin");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            PasswordCheck(input);
        }
        else if(currentScreen == Screen.Win)
        {
            WinScreen(input);
        }
    }

    private void RunMainMenu(string input)
    {
        if (input == "Easy" || input == "Medium" || input == "Hard")
        {
            level = input;
            AskForPassword(level);
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
            Terminal.WriteLine(menuHint);
        };
    }

    void PasswordCheck (string input)
    {
        if( input == password )
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword(level);
        }
    }

     void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case "Easy":
                Terminal.WriteLine("Have a Book...");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
"
                );
                break;
            case "Medium":
                Terminal.WriteLine("Have a Cat ...");
                Terminal.WriteLine(@"
    /\_/\           ___
   = o_o =_______    \ \  -Julie Rhodes-
    __^      __(  \.__) )
(@)<_____>__(_____)____/
");
                break;
            case "Hard":
                Terminal.WriteLine("Congratz, you won a Dragon ");
                Terminal.WriteLine(@"
        ,     \    /      ,        
       / \    )\__/(     / \       
      /   \  (_\  /_)   /   \      
 ____/_____\__\@  @/___/_____\____ 
|             |\../|              |
|              \VV/               |
|        ----------------         |
|_________________________________|
 |    /\ /      \\       \ /\    | 
 |  /   V        ))       V   \  | 
 |/     `       //        '     \| 
 `              V                
                ");
                break;
        }
    }

    void WinScreen(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Hello Antonin");
        }
    }

    void AskForPassword(string level)
    {
        print(level1Passwords.Length);
        print(level2Passwords.Length);
        print(level3Passwords.Length);
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        SetRandomPassword(level);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword(string level)
    {
        switch (level)
        {
            case "Easy":
                password = level1Passwords[Random.Range(0, level1Passwords.Length - 1)];
                break;
            case "Medium":
                password = level2Passwords[Random.Range(0, level2Passwords.Length - 1)];
                break;
            case "Hard":
                password = level3Passwords[Random.Range(0, level3Passwords.Length - 1)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }
}
