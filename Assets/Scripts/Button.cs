using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent onPressed;
    private bool isPressed;

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed) return;
        isPressed = true;

        if (other.gameObject.GetComponent<Player>() == null) return;

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOPunchScale(Vector3.one, .5f));
        sequence.AppendInterval(0.5f);
        sequence.Append(transform.DOMoveY(-1f, 1));
        sequence.AppendCallback(
            
            
            
            () => onPressed.Invoke()
            
            
            );
    }
}