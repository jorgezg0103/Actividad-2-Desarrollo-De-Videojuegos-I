using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{

    protected abstract void performAction();

    private void OnTriggerEnter2D(Collider2D collision) {
        performAction();
        Destroy(gameObject);
    }
}
