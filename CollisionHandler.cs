using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything lookin gud");
                break;
            case "Finish":
                Debug.Log("You're All Done");
                break;
            case "Fuel":
                Debug.Log("Not exists");
                break;
            default:
                ReloadLevel();
                break;
        }
        void ReloadLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
}
