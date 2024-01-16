using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

    
{

    [SerializeField]
    Transform player;
   
    Vector3 offset;
    [SerializeField]
    float smoothTargetTime;

    Vector3 smoothDampVelocity;

    

    private void Awake()
    {
        offset =transform.position - player.position;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset,
           ref smoothDampVelocity, smoothTargetTime);
    }
}
    

