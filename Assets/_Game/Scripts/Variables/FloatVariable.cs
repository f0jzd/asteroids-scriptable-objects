
using UnityEngine;


[CreateAssetMenu(fileName = "new FloatVariable", menuName = "ScriptableObject/Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [Range(0f,10f)]
    [SerializeField] private float _value;

    public float Value => _value;
}

