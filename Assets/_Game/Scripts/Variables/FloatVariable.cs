using UnityEngine;


[CreateAssetMenu(fileName = "new FloatVariable", menuName = "ScriptableObject/Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [Range(0f,10f)]
    [SerializeField] private float _value;

    [TextArea(3,6)]
    [SerializeField] private string _developerDescription;
    
    
    public float Value => _value;
    
    
    private float _currentValue;

    private void OnEnable()
    {
        _currentValue = _value;
    }
}