using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    Vector3 startingPos;
    Transform trans;

    void Start() {
        trans = GetComponent<Transform>();
        startingPos = trans.position;
    }

    void Update() {
        trans.position = new Vector3(startingPos.x, startingPos.y + Mathf.PingPong(Time.time, 2), startingPos.z);
    }
}
