using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerAttack : MonoBehaviour {

    [SerializeField]
    int damage;
    Vector2 direction;

    [SerializeField]
    float attackSpeed = 25;
    float attackTime = 0;
    [SerializeField]
    Vector2 startToEnd = new Vector2(20, 110);

    public GameObject weapond;


    GameObject weapondCopy = null;

    void FixedUpdate()
    {
        meleeAttack();
    }


    void meleeAttack()
    {
        if (Input.GetMouseButton(0) && weapondCopy == null)
        {
            meleeAttackDirection(ref direction);

            if (direction.x > 0)
            {
                weapondCopy = Instantiate(weapond, transform.position, Quaternion.identity, transform);
                weapondCopy.transform.eulerAngles = new Vector3(0, 0, startToEnd.x);
                
            }
            else
            {
                weapondCopy = Instantiate(weapond, transform.position, Quaternion.identity, transform);
                weapondCopy.transform.eulerAngles = new Vector3(0, 0, -startToEnd.x);
                weapondCopy.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (weapondCopy != null)
        {
            attackTime += Time.deltaTime;
            weapondCopy.transform.eulerAngles = new Vector3(0, 0, weapondCopy.transform.eulerAngles.z - (attackSpeed * attackTime * direction.x));

            if (direction.x > 0)
            {
                if (weapondCopy.transform.eulerAngles.z < (360 - startToEnd.y) && weapondCopy.transform.eulerAngles.z > startToEnd.x)
                {
                    Destroy(weapondCopy);
                    weapondCopy = null;
                    attackTime = 0;
                }
            }
            else if (direction.x < 0)
            {
                if (weapondCopy.transform.eulerAngles.z > startToEnd.y && weapondCopy.transform.eulerAngles.z < (360 - startToEnd.x))
                {
                    Destroy(weapondCopy);
                    weapondCopy = null;
                    attackTime = 0;
                }
            }
        }
    }
    void meleeAttackDirection(ref Vector2 direction)
    {
        if (transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            direction = Vector2.left;
        else
            direction = Vector2.right;        
    }
}
