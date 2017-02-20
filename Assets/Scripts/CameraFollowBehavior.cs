using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowBehavior : MonoBehaviour {


    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private float smoothX, smoothY;

    private float refX, refY;

    private Vector2 offset;

    void Start()
    {
        offset = transform.position - targetTransform.position;
    }

    void LateUpdate()
    {
        float x, y;
        x = Mathf.SmoothDamp(transform.position.x, targetTransform.position.x + offset.x, ref refX, smoothX);
        y = Mathf.SmoothDamp(transform.position.y, targetTransform.position.y + offset.y, ref refY, smoothY);

        transform.position = new Vector3(x, y, transform.position.z);
    }

}
