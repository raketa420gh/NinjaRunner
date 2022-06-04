using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEvent _onLongClick;

    private bool _isPointerDown;
    private float _pointerDownTimer;

    private void Update()
    {
        if (_isPointerDown)
        {
            _pointerDownTimer += Time.deltaTime;
            _onLongClick?.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData) => 
        _isPointerDown = true;

    public void OnPointerUp(PointerEventData eventData) => 
        Reset();

    private void Reset()
    {
        _isPointerDown = false;
        _pointerDownTimer = 0f;
    }
}