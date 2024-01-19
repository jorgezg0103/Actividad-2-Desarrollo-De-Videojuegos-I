using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : Item
{

    public static UnityAction OnCoinCollected;

    protected override void performAction() {
        OnCoinCollected.Invoke();
    }
}
