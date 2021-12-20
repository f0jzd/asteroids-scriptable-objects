using ScriptableEvents;
using UnityEngine;

public class Screenwrap : MonoBehaviour
{

    
    [SerializeField] private GameEvent notVisible;

    private Camera mainCamera;
    
    private float leftConstraint = 0.0f;
    private float rightConstraint = 0.0f;
    [SerializeField] private float LeftAndRightbuffer = 1.0f; // set this so the spaceship disappears offscreen before re-appearing on other side
    [SerializeField] private float UpperAndLowerBuffer = 1.0f; // set this so the spaceship disappears offscreen before re-appearing on other side
    public float distanceZ = 10.0f;
    [SerializeField] private float upperConstraint;
    [SerializeField] private float lowerConstraint;


    private void Start()
    {
        mainCamera = Camera.main;;
        leftConstraint = mainCamera.ScreenToWorldPoint( new Vector3(0.0f, 0.0f, distanceZ) ).x;
        rightConstraint = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        
        upperConstraint = mainCamera.ScreenToWorldPoint( new Vector3(0.0f, Screen.height, distanceZ) ).y;
        lowerConstraint = mainCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
    }
    
    public void ScreenWrap()
    {
        if (transform.position.x < leftConstraint - LeftAndRightbuffer) 
        { // ship is past world-space view / off screen
            transform.position = new Vector3(rightConstraint + LeftAndRightbuffer,transform.position.y);  // move ship to opposite side
        }
        if (transform.position.x > rightConstraint + LeftAndRightbuffer) {
            transform.position = new Vector3(leftConstraint - LeftAndRightbuffer,transform.position.y);  // move ship to opposite side
        }
        if (transform.position.y < lowerConstraint - UpperAndLowerBuffer) { // ship is past world-space view / off screen
            transform.position = new Vector3(transform.position.x,upperConstraint + UpperAndLowerBuffer);  // move ship to opposite side
        }
        if (transform.position.y > upperConstraint + UpperAndLowerBuffer) {
            transform.position = new Vector3(transform.position.x,lowerConstraint - UpperAndLowerBuffer);  // move ship to opposite side
        }
    }

    public void Update()
    {
        if (transform.position.x < leftConstraint - LeftAndRightbuffer)
            notVisible.Raise();
        if (transform.position.x > rightConstraint + LeftAndRightbuffer)
            notVisible.Raise();
        if (transform.position.y < lowerConstraint - UpperAndLowerBuffer)// ship is past world-space view / off screen
            notVisible.Raise();
        if (transform.position.y > upperConstraint + UpperAndLowerBuffer)
            notVisible.Raise();
    }
}
    
