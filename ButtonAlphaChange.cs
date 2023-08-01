using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ArcaneGames.UI
{
    public class ButtonAlphaChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
    {
        [SerializeField] private bool interactable = true;
        public bool Interactable
        {
            get => interactable;
            set
            {
                if (interactable == value) return;
            
                interactable = value;
                SetButtonAlpha(value ? normalAlpha : disabledAlpha);
            }
        }

        [Range(0f, 1f)] public float normalAlpha = 1f;
        [Range(0f, 1f)] public float highlightedAlpha = 0.8f;
        [Range(0f, 1f)] public float pressedAlpha = 0.5f;
        [Range(0f, 1f)] public float disabledAlpha = 0.5f;
        [Range(0f, 1f)] public float fadeDuration = 0.1f;

        [Space(20)]
        public UnityEvent onClick = new();

        private Graphic[] _childGraphics;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _childGraphics = GetComponentsInChildren<Graphic>();
        
            SetButtonAlpha(interactable ? normalAlpha : disabledAlpha);
        }
#endif
    
        private void Start()
        {
            _childGraphics = GetComponentsInChildren<Graphic>();

            SetButtonAlpha(interactable ? normalAlpha : disabledAlpha);
        }

        private void OnDisable()
        {
            SetButtonAlpha(interactable ? normalAlpha : disabledAlpha);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!interactable) return;
        
            SetButtonAlpha(highlightedAlpha);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!interactable) return;
        
            SetButtonAlpha(normalAlpha);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable) return;
        
            SetButtonAlpha(pressedAlpha);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!interactable) return;
        
            onClick.Invoke();
        }

        private void SetButtonAlpha(float targetAlpha)
        {
            foreach (Graphic graphic in _childGraphics)
            {
                graphic.CrossFadeAlpha(targetAlpha, fadeDuration, true);
            }
        }
    }
}
