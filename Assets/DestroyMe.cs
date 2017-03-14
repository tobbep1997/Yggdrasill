using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

    [SerializeField]
    float time = 3;

    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > time)
        {
            Destroy(gameObject);
        }

    }
}
