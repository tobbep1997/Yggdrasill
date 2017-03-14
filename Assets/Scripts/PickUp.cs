using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    [SerializeField]
    changePicture pic;


    [SerializeField]
    bool armor = true;

    [SerializeField]
    float sizeScale = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (armor)
            {
                pic.ChangePicture();              
            }
            else
            {
                collision.transform.GetComponent<playerAttack>().scale += new Vector3(1 * sizeScale, 1 * sizeScale, 1 * sizeScale);                
            }
            Destroy(gameObject);
        }
    }
}
