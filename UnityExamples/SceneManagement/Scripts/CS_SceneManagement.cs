using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_SceneManagement : MonoBehaviour
{
    void Start()
    {
        // Initializes the value of _HasBeenTriggered on game start
        _HasBeenTriggered = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SelectScene.ToString(), LoadSceneMode.Single);
            // LoadScene.Additive loads the scene onto the active scene
            //SceneManager.LoadScene(SelectScene.ToString(), LoadSceneMode.Additive);

            // An alternative to the basic SceneManager.LoadScene, you can load a scene
            // asynconously, meaning that the scene will only open once it has fully loaded.
            // StartCoroutine(LoadSceneAsync(LoadSceneMode.Single));
        }
    }
    /* UNCOMMENT FOR ADDING SCENE TO EXISTING SCENE */
    //
    // Summary:
    //      Preforms the level loading based on the player entering a trigger area
    /*
     void OnTriggerEnter(Collider other)
    {
        // If the collided object is the player and the box hasn't been triggered before.
        if (other.gameObject.name == "Player" && !_HasBeenTriggered)
        {
            if (UnloadScene)
            {
                // Asynchronously unloads the selected scene.
                SceneManager.UnloadSceneAsync(SelectScene.ToString());
            }
            else
            {
                // A switch case. Not needed, but is important to know what it looks like.
                // You could just do StartCoroutine(LoadSceneAsync(LoadSceneMode.Additive));
                // and ignore the switch case entierly, but if you want to preform any special
                // commands based on the selected level, this is how you'd do it.
                switch (SelectScene)
                {
                    case SceneSelection.Scene_1:
                        //Some unique action based on scene selection
                        // Load scene *into* existing scene.
                        StartCoroutine(LoadSceneAsync(LoadSceneMode.Additive));
                        // a break statement is required at the end of each case statement.
                        break;
                    case SceneSelection.Scene_2:
                        //Some unique action based on scene selection
                        // Load scene *into* existing scene.
                        StartCoroutine(LoadSceneAsync(LoadSceneMode.Additive));
                        // a break statement is required at the end of each case statement.
                        break;
                }
            }
            // Updates the _HasBeenTriggered value to true, meaning the OnTriggerEnter can not
            // be triggered again.
            _HasBeenTriggered = true;
        }
    }
    */
    //
    // Summary:
    //      Loads a scene asynconously. It will load a scene only once the scene fully loads.
    //
    // Parameters:
    //   lsm:
    //     The enum value of LoadSceneMode. Either LoadSceneMode.Additive or LoadSceneMode.Single.
    //
    // Returns:
    //     null
    IEnumerator LoadSceneAsync(LoadSceneMode lsm)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SelectScene.ToString(), lsm);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

  
    //
    // Summary:
    //      This enum holds the values of the scenes to load
    public enum SceneSelection
    {
        Scene_1,
        Scene_2
    }
    //
    // Summary:
    //      A public enum that shows the scene selections in the inspector window.
    public SceneSelection SelectScene;
    //
    // Summary:
    //      A public bool that allows the user to choose whether to async load or
    //      unload scenes.
    public bool UnloadScene;
    //
    // Summary:
    //      Ensures that once that loading/unloading the scene can happen only once.
    private bool _HasBeenTriggered;
}
