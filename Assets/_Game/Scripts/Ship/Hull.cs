using ScriptableEvents;
using UnityEngine;
using Variables;

namespace Ship
{
    public class Hull : MonoBehaviour
    {
        
        
        [SerializeField] private IntVariable _health;
        [SerializeField] private IntReference _healthReference;
        //[SerializeField] private ScriptableEventBase _onHealthChangedEvent;
        [SerializeField] private ScriptableEventInt _onHealthChangedEvent;
        
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (string.Equals(other.gameObject.tag, "Asteroid"))
            {
                
                
                Debug.Log("Hull collided with Asteroid");
                //TODO can we bake this into one call?
                //_healthReference.ApplyChange(-1);
                //_healthReference.ApplyChange(-1);
                _health.ApplyChange(-1);
                _onHealthChangedEvent.Raise(_health.Value);
            }
        }
    }
}
