using ScriptableEvents;
using UnityEngine;

namespace DefaultNamespace
{
    public class MyMono : MonoBehaviour
    {
        [SerializeField] private FloatRef _myNewName;
        [SerializeField] private GameEvent _event;


        //[SerializeField] private TextMeshProUGUI _text;

        public void Update()
        {
            if (Input.anyKey)
            {
                _event.Raise();
            }

            //_text.text = _myFloatRef.Value.ToString();
        }

        public void MyMethod()
        {
            Debug.Log("My Method was called");
        }

        public void OnMouseClick(Vector3 value)
        {
            Debug.Log(value);
        }
    }
}