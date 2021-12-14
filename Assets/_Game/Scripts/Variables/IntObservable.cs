using ScriptableEvents;
using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(fileName = "new Int Observable", menuName = "ScriptableObject/Variables/Int Observable")]
    public class IntObservable : IntVariable
    {
        [SerializeField] private ScriptableEventIntReference _onValueChangedEvent;
        
        
        public override void ApplyChange(int change)
        {
            base.ApplyChange(change);
            _onValueChangedEvent.Raise(new IntReference(this));
        }
    }
}