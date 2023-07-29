using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ArcaneGames.UI
{
    public class ButtonAlphaChange : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler,
        IPointerUpHandler, IPointerClickHandler, IDeselectHandler
    {
        public bool interactable = true;
        public bool Interactable
        {
            get => interactable;
            set
            {
                SetAlpha(value ? normalAlpha : disabledAlpha, fadeDuration);
                interactable = value;
            }
        }
    
        [Range(0f,1f)] public float normalAlpha = 1f;
        [Range(0f,1f)] public float highlightedAlpha = 0.8f;
        [Range(0f,1f)] public float pressedAlpha = 0.5f;
        [Range(0f,1f)] public float disabledAlpha = 0.5f;
        [Range(0f,1f)] public float fadeDuration = 0.1f;

        [Space(20)]
        public UnityEvent onClick = new();

        private Graphic[] _childGraphics;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _childGraphics = GetComponentsInChildren<Graphic>();
        
            SetAlpha(interactable ? normalAlpha : disabledAlpha, fadeDuration);
        }
#endif

        private void OnDisable()
        {
            SetAlpha(normalAlpha, 0f);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!interactable) return;
        
            SetAlpha(highlightedAlpha, fadeDuration);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable) return;
        
            SetAlpha(pressedAlpha, fadeDuration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!interactable) return;
        
            SetAlpha(normalAlpha, fadeDuration);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!interactable) return;
        
            SetAlpha(normalAlpha, fadeDuration);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!interactable) return;
        
            onClick.Invoke();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            SetAlpha(disabledAlpha, fadeDuration);
        }

        private void SetAlpha(float alpha, float duration, bool ignoreTimeScale = true)
        {
            foreach (Graphic graphic in _childGraphics)
            {
                graphic.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
            }
        }
    }
}