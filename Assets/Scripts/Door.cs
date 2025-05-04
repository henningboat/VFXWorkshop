using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        transform.DOScale(Vector3.zero, 1);
        transform.DORotate(new Vector3(0, 0, 180), 1).OnComplete(()=>Destroy(gameObject));
    }
}