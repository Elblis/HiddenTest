using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HiddenTest
{
    public class TimerManager : MonoBehaviour
    {
        private float _timeLeftSeconds;
        private Text timerText;

        IUIManager _uiManager;

        [Inject]
        void Construct(LevelSettings settings, IUIManager uiManager)
        {
            _uiManager = uiManager;
            _timeLeftSeconds = settings.TimerSeconds;
            gameObject.SetActive(settings.IsTimerEnabled);
        }

        private void Awake()
        {
            timerText = GetComponent<Text>();
        }

        void Update()
        {
            try
            {

                if ( !enabled || _timeLeftSeconds <= 0f)
                    return;

                _timeLeftSeconds -= Time.deltaTime;
                int seconds = Mathf.CeilToInt(_timeLeftSeconds);
                int m = seconds / 60;
                int s = seconds % 60;
                if (timerText != null) timerText.text = $"{m:00}:{s:00}";

                if (_timeLeftSeconds <= 0f)
                {
                    if (_uiManager != null) _uiManager.ShowLose();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }
    }

}
