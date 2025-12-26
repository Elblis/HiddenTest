using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using System.Collections;
using UnityEngine.EventSystems;
using System;

namespace HiddenTest
{

    [RequireComponent(typeof(Collider2D))]
    public class SelectableItem : MonoBehaviour, IPointerClickHandler
    {
        public int Id { get => this.gameObject.GetInstanceID(); } 

        [SerializeField]
        private bool _isEnabled = true;
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }
        public string Name { get => this.gameObject.name; }

        SpriteRenderer _sr;
        IGameController _gameController;

        [Inject]
        void Construct(IGameController gameController)
        {
            _gameController = gameController;
        }

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            Debug.Log($"Предмет инициализирован ({Name})");
        }


        IEnumerator FadeAndDisable()
        {
            float t = 0f;
            float duration = 0.6f;
            Color start = _sr.color;
            while (t < duration)
            {
                t += Time.deltaTime;
                float a = Mathf.Lerp(1f, 0f, t / duration);
                _sr.color = new Color(start.r, start.g, start.b, a);
                yield return null;
            }
            gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            try
            {
                if (_gameController == null)
                    return;

                if (_gameController.CanPickItem(Id))
                {
                    StartCoroutine(FadeAndDisable());
                    _isEnabled = false;
                    _gameController.OnItemFound(Id);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }
    }
}
