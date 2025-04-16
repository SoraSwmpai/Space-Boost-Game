using System;
using Unity.VisualScripting;
using UnityEngine;

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
                Debug.Log("You Crashed Dummy");
                break;
        }

        

    }
}
