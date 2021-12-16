using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Transform target = null;
    [SerializeField]
    float speed = 2.0f,
          innerBuffer = 0.1f,
          outerBuffer = 1.5f;
    bool moving;
    Vector3 offset;

    private void Start()
    {
        offset = target.position + transform.position;
    }

    // follow the player
    private void Update()
    {
        Vector3 cameraTargetPosition = target.position + offset;
        Vector3 heading = cameraTargetPosition - transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;

        if(distance > outerBuffer)
        {
            moving = true;
        }

        // use buffers to speed up and slow down the following speed
        if (moving)
        {
            
            if (distance > innerBuffer)
            {
                // follow the target
                transform.position += direction * Time.deltaTime * speed * Mathf.Max(distance, 1f);
            }
            else
            {
                // snap the position
                transform.position = cameraTargetPosition;
            }
        }
       
    }
}
