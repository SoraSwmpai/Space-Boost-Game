using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApllication : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }
}
