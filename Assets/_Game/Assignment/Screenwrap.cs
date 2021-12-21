using ScriptableEvents;
using ScriptableEvents.GameEvents;
using UnityEngine;

public class Screenwrap : MonoBehaviour
{

    
    [SerializeField] private GameEventTransform notVisible;

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
    
    public void ScreenWrap(Transform shipPosition)
    {
        if (shipPosition.position.x < leftConstraint - LeftAndRightbuffer) 
        { // ship is past world-space view / off screen
            shipPosition.position = new Vector3(rightConstraint + LeftAndRightbuffer,shipPosition.position.y);  // move ship to opposite side
        }
        if (shipPosition.position.x > rightConstraint + LeftAndRightbuffer) {
            shipPosition.position = new Vector3(leftConstraint - LeftAndRightbuffer,shipPosition.position.y);  // move ship to opposite side
        }
        if (shipPosition.position.y < lowerConstraint - UpperAndLowerBuffer) { // ship is past world-space view / off screen
            shipPosition.position = new Vector3(shipPosition.position.x,upperConstraint + UpperAndLowerBuffer);  // move ship to opposite side
        }
        if (shipPosition.position.y > upperConstraint + UpperAndLowerBuffer) {
            shipPosition.position = new Vector3(shipPosition.position.x,lowerConstraint - UpperAndLowerBuffer);  // move ship to opposite side
        }
    }
}
    
