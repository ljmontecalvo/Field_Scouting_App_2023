using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accounts : MonoBehaviour
{
    public string accountName;
    public string[] allNames = { // <-- List of Names
        "Tom", 
        "Aidan", 
        "Paige", 
        "Mike", 
        "Mark", 
        "Joe", 
        "Kim", 
        "Alex", 
        "Timothy", 
        "Josh", 
        "Rick", 
        "Gary", 
        "Gregory", 
        "Peter", 
        "Liz", 
        "Geoff", 
        "Will", 
        "Austin", 
        "David", 
        "David", 
        "Connor", 
        "Haily", 
        "Colton", 
        "Gio", 
        "Tony", 
        "Jack", 
        "Tess", 
        "Maddie", 
        "Nehuel", 
        "Alexanders", 
        "Nathan", 
        "Jack", 
        "Landon", 
        "Joeseph", 
        "Logan", 
        "Piper", 
        "Ethan", 
        "Laura", 
        "Emma", 
        "Addison", 
        "Inesh", 
        "Cam", 
        "Jacob",
        "Admin",
        "A",
        "L",
        "Parent",
        "Kitara",
        "George",
        "Jackson",
        "Jayden"
    };

    private void Start()
    {
        DontDestroyOnLoad(gameObject); // Keeps the accounts object active through all screens.
    }
}
