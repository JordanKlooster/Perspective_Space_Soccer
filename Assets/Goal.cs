using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour {


    public GameObject managerObject;

    private Manager manager; // accessing the manager script

    bool exists;

    int nextScene;


    //public SceneManagement.LoadSceneMode mode = LoadScen v eMode.Single;



        // Attempt to find manager script so beating a level increases an integer 

    void Awake() {
        //managerObject = AssetBundle.LoadAsset("Game Manager", GameObject);
        try {
            managerObject = GameObject.Find("Game Manager");
            manager = managerObject.GetComponent<Manager>();
            Debug.Log("Successfully found Game manager");
        }
        catch {
            Debug.Log("couldn't find Game Manager object. Can't load scene normally, will use backup load system.");
        }
        /*
        if (GameObject.Find("Game Manager") == null)
        {
            Instantiate(managerObject, new Vector3(0,0,0), new Quaternion(1,0,0,0) );
            exists = false;
        }
        else {
            exists = true;
        }*/

    }



    //void Start () {

        /*
        if (exists)
        {
            manager = managerObject.GetComponent<Manager>();
        }*/

	//}   // end void Start
	
	
	//void Update () {

        
        
	//}   // end void Update

    /*
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }
    */

    void OnTriggerEnter2D(Collider2D other)
    {
        try         // Give score to players when there's a red and a blue net
        {

            //if (other.gameObject.CompareTag("End"))
            //{
            //    manager.TimeWon += 1;
            //    Debug.Log("Manager TimeWon ++");
            //}


            // hey there -Tony


            // Increase players score when they score on opposite colour net

            if (other.gameObject.CompareTag("Red net"))
            {
                manager.BPoints += 1;
                Debug.Log("Successfully added points to player");
            }
            else if (other.gameObject.CompareTag("Blue net"))
            {
                manager.RPoints += 1;
                Debug.Log("Successfully added points to player");
            }
            
        }
        catch
        {
            Debug.Log("Couldn't change players points, probably because manager isn't accessible.");
        }



        // if they Score execute this code, increase timesWon variable if it's last level, and load next level

        if (other.gameObject.CompareTag("Goal") || other.gameObject.CompareTag("Red net") || other.gameObject.CompareTag("Blue net") )
        {
            // Scoring at level 11 or higher go to start and increase TimeWon

            try     // When you Score Go to Next Level
            {
                Debug.Log("at the if statement in goal script. next scene: " + manager.nextScene);
                if (manager.nextScene >= 11)
                {      // at the end of the game the goal bring you to the start.
                    Debug.Log("ok Lets go back to step 1");
                    manager.nextScene = 0;

                    manager.TimeWon += 1;
                    Debug.Log("Manager TimeWon ++, TimeWon = " + manager.TimeWon);
                }
            }
            catch
            {
                Debug.Log("couldn't access manager for increasing TimeWon variable");
            }




            // this just loads next level

            try     // When you Score Go to Next Level
            {
                //Debug.Log("Trying new loading system");

                manager.Next();
                Debug.Log("IT WORKS!");
            }
            catch
            {
                //try backup hack of loading the level using the name of the level as the int (I was really proud of this)

                Debug.Log("New load system didn't work.");
                try
                {
                    nextScene = int.Parse(other.gameObject.name);

                    Debug.Log("trying old system: Next Scene " + (nextScene));

                    SceneManager.LoadScene(nextScene);
                }
                catch
                {
                    Debug.Log("duct tape load didn't work");
                }
            }





            /*
            try
            {
                nextScene = int.Parse(other.gameObject.name);
                
                try
                {
                    manager.nextScene = nextScene;

                }
                catch
                {
                    Debug.Log("couldn't set manager.nextScene equal to nextScene ");
                }
            }
            catch
            {
                Debug.Log("didn't turn the other.gameObject.name into int nextScene");
                try
                {
                    nextScene = manager.nextScene;
                }
                catch
                {
                    Debug.Log("couldn't get nextScene to be manager.next scene");
                }
            }
            


            
            Debug.Log("Next Scene" + (nextScene));

            SceneManager.LoadScene(nextScene);
            */

            //curen

            //Debug.Log("after first loadscene");
            //LoadLvlScene(1);
            //Debug.Log("2nd didn't work");


        }
        //Debug.Log(other.gameObject.name + " Enter");
    }// end of OnTriggerEnter2D




  


    /*
    public void LoadLvlScene(int next)
    {
        SceneManager.LoadScene(next);
    }*/
}
