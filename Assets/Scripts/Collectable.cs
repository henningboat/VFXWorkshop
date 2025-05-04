using System;
using DG.Tweening;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool collected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (collected)
        {
            return;
        }
        collected = true;
        
        var player = other.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        transform.DOMove(player.transform.position, 0.1f);
        transform.DOScale(Vector3.one * 0.1f, 0.1f).SetEase(Ease.InOutBounce).OnComplete(() => { ScoreManager.Instance.CollectPoint();});
    }
}
