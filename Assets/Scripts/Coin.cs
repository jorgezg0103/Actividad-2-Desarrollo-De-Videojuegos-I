using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{

    public static UnityAction OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D collision) {
        OnCoinCollected.Invoke();
        Destroy(gameObject);
    }
}
