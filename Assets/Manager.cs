using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour {

    //static SceneManager Instance;

    public int RPoints = 0; // points from the soocer levels
    public int BPoints = 0;
    public int nextScene = 5; // the value of the current scene to load

    private bool atCreditsLevel = false;

    public int TimeWon = 0; // # of times you beat the game, used for showing secret messages

    public GameObject pauseM;

    //private string[,] inputs;

    public string[] inputs = new string[] {"Horizontal", "Vertical", "H2", "V2"};


    void Start()//maybe awake
    {
        /*
        inputs = new string[2,2];   //this is so I can switch the inputs after the last level
        inputs[0, 0] = "Horizontal";
        inputs[0, 1] = "Vertical";
        inputs[1, 0] = "H2";
        inputs[1, 1] = "V2";
        */


        GameObject.DontDestroyOnLoad(gameObject);

        pauseM.SetActive(false);
        Next();
        /*
        if (Instance != null)
        {
            GameObject.Destroy();
        }else
        {

        }*/
    }   // END OF Start


    void Update()
    {

        // Call these load functions when you press the buttons

        if (Input.GetButtonDown("Change Scene") && Input.GetAxisRaw("Change Scene") > 0)   // Press n for Next Scene
        {
            Next();
        }
        else if (Input.GetButtonDown("Change Scene") && Input.GetAxisRaw("Change Scene") < 0)
        {
            Back();
        }
        else if (Input.GetButtonDown("Reload") && Input.GetAxisRaw("Reload") > 0)
        {
            Reload();
        }// END Next Scene


        // toggles the pause menu

        if (Input.GetButtonDown("Pause") && nextScene != 0 )/* actually want the main menu not lvl 0 */  // PAUSE GAME
        {
            Debug.Log("Pressed esc in Manager");

            TogglePause();
        }   // END PAUSE GAME




    }// END OF Update()




    //these are all about loading levels

    public void Next() // Go to next Level
    {
        if (nextScene < 11) // made it >1 so the first level isn't loaded multiple times.
        {
            nextScene += 1;
            //Debug.Log(nextScene);
            SceneManager.LoadScene(nextScene);//it's actually the current scene because I loaded the next scene
        }
    }


    public void Back() // Go to previous level
    {
        
        if (nextScene > 1) // made it >1 so the first level isn't loaded multiple times.
        {
            nextScene -= 1;
            SceneManager.LoadScene(nextScene);
        }
    }


    public void Reload() // Reload current level
    {    
        
        SceneManager.LoadScene(nextScene);
    }


    public void ToggleCredits() //Go to credits level (or go back) & close Menu
    {
        if (!atCreditsLevel)
        {
            // if not at credits level go there
            atCreditsLevel = true;
            TogglePause();
            SceneManager.LoadScene(12);
        }
        else
        {
            TogglePause();
            Reload(); //just reload the scene you were at
            
        }
    }





    public void QuitGame() //Just Quiting the game
    {
        //Debug.Log("Ending Game");
        Application.Quit();
    }


    public void TogglePause() //Opens or closes the Pause Menu (this doesn't stop force being added)
    {
        if (Time.timeScale == 0 )
        {
            Time.timeScale = 1;

            pauseM.SetActive(false);
            Debug.Log("Unpaused");
        }
        else {
            Time.timeScale = 0;

            //Debug.Log("Pretend the menu appears");
            pauseM.SetActive(true);
            Debug.Log("Paused");
        }


    }   // END TogglePause()


    //public void ToggleInputs()
    //{

        // if regular == true set it to false
        // and flip cameras have if (bool == false){cam.transform. whatever = flipped}
        
        // player.input.switch
        
        // give players a bool for wich character they are and use bool = !bool
        //use the player.bool to set the player. 
        
        //if (input.H != "Horizontal"){ inputH = "Horizontal"} 


    //}


}
