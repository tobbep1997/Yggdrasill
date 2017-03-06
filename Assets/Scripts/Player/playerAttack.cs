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

    [SerializeField]
    float projectileSpeed = 250, attackCooldown = .5f;
    

    public enum attackType { meele, ranged}
    public attackType aType = attackType.meele;
    

    public GameObject weapond;

    public PlayerBehavior pb;


    GameObject weapondCopy = null;

    [SerializeField]
    KeyCode attackKey = KeyCode.Z;

    [SerializeField]
    Transform pivotPoint = null;

    void FixedUpdate()
    {
        if (!pb.enableControlls)
            return;
        switch (aType)
        {
            case attackType.meele:
                meleeAttack();
                break;
            case attackType.ranged:
                rangedAttack();
                break;
            default:
                break;
        }
    }

    void rangedAttack()
    {
        attackTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && attackTime > attackCooldown)
        {
            attackTime = 0;
            GameObject bullet;
            if (pivotPoint == null)
                bullet = Instantiate(weapond, transform.position, Quaternion.identity);
            else
                bullet = Instantiate(weapond, pivotPoint.position, Quaternion.identity);

            rangedAttackDirection(ref direction);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);

        }
    }
    void rangedAttackDirection(ref Vector2 vector)
    {
        vector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
    }

    void meleeAttack()
    {
        if (Input.GetKey(attackKey) && weapondCopy == null)
        {
            meleeAttackDirection(ref direction);

            if (direction.x > 0)
            {
                if (pivotPoint == null)
                {
                    weapondCopy = Instantiate(weapond, transform.position, Quaternion.identity, transform);
                }
                else
                {
                    weapondCopy = Instantiate(weapond, pivotPoint.position, Quaternion.identity, transform);
                }
                    weapondCopy.transform.eulerAngles = new Vector3(0, 0, startToEnd.x);
                
            }
            else
            {
                if (pivotPoint == null)
                {
                    weapondCopy = Instantiate(weapond, transform.position, Quaternion.identity, transform);
                }
                else
                {
                    weapondCopy = Instantiate(weapond, pivotPoint.position, Quaternion.identity, transform);
                }
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
        direction.x = pb.direction;
    }
}
