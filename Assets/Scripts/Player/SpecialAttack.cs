using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour {

    [SerializeField]
    KeyCode key;

    public float time = 1;
    public float timeTilDone = 1;
    private float doneTimer = 0;
    private float timer = 0;

    [SerializeField]
    GameObject weapond, lighnings;
    GameObject weapondCopy = null;
    GameObject lighningCopy = null;

    PlayerBehavior pb;


    [SerializeField]
    Transform pivotPoint = null;

    bool done = true;


    private void Start()
    {
        pb = GetComponent<PlayerBehavior>();
    }

    void Update()
    {
        if (Input.GetKey(key) && done)
        {
            pb.enableControlls = false;

            timer += Time.deltaTime;
            if (weapondCopy == null)
            {
                if (pivotPoint == null)
                {
                    weapondCopy = Instantiate(weapond, transform.position, Quaternion.identity,transform);
                }
                else
                {
                    weapondCopy = Instantiate(weapond, pivotPoint.position, Quaternion.identity,transform);
                }
            }
            
            if (timer >= time)
            {
                doneTimer += Time.deltaTime;
                if (doneTimer > timeTilDone)
                    done = false;
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
            done = true;
            doneTimer = 0;
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
