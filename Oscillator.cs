using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private float speed;
    
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float movementFactor;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + movementVector;
    }

    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startPosition, endPosition, movementFactor); // start, to , speed factor
    }
}
