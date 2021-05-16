using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine("My Name Is Mr Code");
        GreetUser();
    }

    void GreetUser()
    {
        Terminal.WriteLine("Hello Ben");
    }
}
