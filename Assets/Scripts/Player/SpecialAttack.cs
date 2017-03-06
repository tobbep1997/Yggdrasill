using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour {

    [SerializeField]
    KeyCode key;

    public float time = 1;
    private float timer = 0;

    [SerializeField]
    GameObject weapond, lighnings;
    GameObject weapondCopy = null;
    GameObject lighningCopy = null;

    PlayerBehavior pb;


    [SerializeField]
    Transform pivotPoint = null;

    private void Start()
    {
        pb = GetComponent<PlayerBehavior>();
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            pb.enableControlls = false;

            timer += Time.deltaTime;
            if (weapondCopy == null)
            {
                if (pivotPoint == null)
                {
                    weapondCopy = Instantiate(weapond, transform.position, Quaternion.identity);
                }
                else
                {
                    weapondCopy = Instantiate(weapond, pivotPoint.position, Quaternion.identity);
                }
            }
            weapondCopy.transform.SetParent(transform);
            if (timer >= time)
            {
                Destroy(weapondCopy);
                if (lighningCopy == null)
                {
                    if (pivotPoint == null)
                    {
                        lighningCopy = Instantiate(lighnings, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        lighningCopy = Instantiate(lighnings, pivotPoint.position, Quaternion.identity);
                    }
                  
                }
               
                //lighningCopy.transform.SetParent(pivotPoint);
                lighningCopy.transform.localScale = new Vector3(pb.direction, 1, 1);
            }
            
        }
        else
        {
            pb.enableControlls = true;
            timer = 0;
            if (weapondCopy != null)
            {
                Destroy(weapondCopy);
                weapondCopy = null;
            }
            if (lighningCopy != null)
            {
                Destroy(lighningCopy);
                lighningCopy = null;
            }
        }
    }
}
