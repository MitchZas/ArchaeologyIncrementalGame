using UnityEngine;
using System.Collections;

public class CoinHit : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log(gameObject);
        Destroy(gameObject);
    }
}
