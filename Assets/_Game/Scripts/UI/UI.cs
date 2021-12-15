using System;
using ScriptableEvents;
using Ship;
using TMPro;
using UnityEngine;
using Variables;

namespace UI
{
    public class UI : MonoBehaviour
    {
        
        [Header("Health: ")]
        [SerializeField] private IntVariable _healthVar;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private ScriptableEventIntReference OnHealthChangedEvent;
        
        [Header("Score: ")] 
        [SerializeField] private IntVariable _points;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private ScriptableEventIntReference OnPointsChangedEvent;
        
        
        [Header("Timer: ")]
        [SerializeField] private TextMeshProUGUI _timerText;
        
        [Header("Laser: ")]
        [SerializeField] private TextMeshProUGUI _laserText;


        /*private void Update()
        {
            //TODO do we need to call this every frame?
            
            SetHealthText($"Health: {_healthVar.Value}");
        }*/


        /*private void OnEnable()
        {
            OnHealthChangedEvent.Register(OnHealthChange);
            OnPointsChangedEvent.Register(OnPointsChange);
        }
        private void OnDisable()
        {
            OnHealthChangedEvent.UnRegister(OnHealthChange);
            OnPointsChangedEvent.UnRegister(OnPointsChange);
        }*/

        private void Start()
        {
            SetHealthText($"Health: {_healthVar.Value}");
            SetScoreText($"Score: {_points.Value}");
        }

        public void OnHealthChange(int newValue)
        {
            Debug.Log("OnHealthChanged");
            SetHealthText($"Health: {_healthVar.Value}");
        }
        
        
        private void SetHealthText(string text)
        {
            _healthText.text = text;
        }

        public void OnPointsChange(int newValue)
        {
            Debug.Log("Points changed");
            SetScoreText($"Score: {_points.Value}");
        }
        
        private void SetScoreText(string text)
        {
            _scoreText.text = text;
        }
        
        private void SetTimerText(string text)
        {
            _timerText.text = text;
        }
        
        private void SetLaserText(string text)
        {
            _laserText.text = text;
        }
    }
}
