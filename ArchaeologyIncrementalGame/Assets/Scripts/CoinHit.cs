using UnityEngine;
using System;

public class CoinHit : MonoBehaviour, IClickable
{
    public static event Action onCoinCollected;

    public void OnClick()
    {
        Debug.Log(gameObject);
        onCoinCollected();
        Destroy(gameObject);
    }
}
