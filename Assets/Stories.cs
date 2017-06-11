using UnityEngine;
using System.Collections;

public class Stories : MonoBehaviour
{


    public GameObject managerObject;

    private Manager manager;

    public GameObject s1;
    public GameObject s2;
    public GameObject s4;



    // Find object and Manager script see how many times you've won, if it's too low disable the text objects

    void Awake()
    {

        // This gave me a lot of frustration. You have to use GameObject.Find or something similar, just a public 
        // variable doesn't work.

        managerObject = GameObject.Find("Game Manager"); 
        //manager = managerObject.GetComponent<Manager>();

        //Debug.Log("manager.TimeWon: " + manager.TimeWon);

        
        Debug.Log("Awake of Stories");

        try
        {
            manager = managerObject.GetComponent<Manager>();
            Debug.Log("manager.TimeWon: " + manager.TimeWon);

            if (manager.TimeWon < 3)
            {
                
                s4.SetActive(false);
            }

            if (manager.TimeWon < 2)
            {

                s2.SetActive(false);
            }

            if (manager.TimeWon < 1)
            {

                s1.SetActive(false);
            }

        }
        catch
        {
            Debug.Log("This is Stories Awake Catch");
        }

    }

    /*
    void update() {
        if (manager.TimeWon >= 3)
        {

            s4.SetActive(true);
        }

        if (manager.TimeWon >= 2)
        {

            s2.SetActive(true);
        }

        if (manager.TimeWon >= 1)
        {

            s1.SetActive(true);
        }
    }*/


    // Display (Activate) text boxes based on value of timesWon int
    /*
    void Start()
    {

        Debug.Log("Start of Stories");

        manager = managerObject.GetComponent<Manager>();

        s1.SetActive(false);
        s2.SetActive(false);
        s4.SetActive(false);



        try
        {
            Debug.Log("start try on stories");
            Debug.Log("manager.TimeWon: " + manager.TimeWon);
            if (manager.TimeWon >= 3)
            {
                s1.SetActive(true);
                s2.SetActive(true);
                s4.SetActive(true);
            }
            else if (manager.TimeWon >= 2)
            {
                s1.SetActive(true);
                s2.SetActive(true);
            }
            else if (manager.TimeWon >= 1)
            {
                s1.SetActive(true);
                Debug.Log("Set s1 to active");
            }

            Debug.Log("The Try on Stories appearently worked");
        }
        catch
        {
            Debug.Log("this is the catch on Stories");
        }

    }*/


    
}
