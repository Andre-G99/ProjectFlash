using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private static Transform target;
    public Vector3 offset;

    [Range(1,10)]
    public float smoothFactor;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
   }
    void FixedUpdate()
    {
        if(target == null){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = targetPosition;
    }

}
