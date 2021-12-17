using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ElementSO : ScriptableObject
{

   
   [Tooltip("The elements thgat are defeated by this element are: ")]
   public List<ElementSO> DefeatedElement = new List<ElementSO>();

   public string myString = "Hello";
   public float myFloat = 13.37f;

}