using System;
using UnityEngine;
using UnityEngine.InputSystem; //read doc zora

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction thrust; //named it thurst it takes input action to thurst

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        thrust.Enable();
    }

    private void Update()
    {
        if (thrust.IsPressed())
        {
            
        }
    }


    private void FixedUpdate()
    {
        throw new NotImplementedException();
    }
}
