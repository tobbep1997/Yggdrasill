using System.Configuration;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
class Enemy : MonoBehaviour
{
    Vector2 startDir = Vector2.right;

    Rigidbody2D rigid2D;
    BoxCollider2D col;

    [SerializeField]
    float speed = 25;

    Animator a;
    
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        a = GetComponent<Animator>();
        startDir = new Vector2((int)(startDir.x * -1), 0);
        transform.localScale = new Vector3(startDir.x * Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
    }

    void Update()
    {
        rigid2D.MovePosition(rigid2D.position + (startDir * speed * Time.deltaTime));
        if (checkEnd() || checkWall())
        {
            startDir = new Vector2((int)(startDir.x * -1), 0);
            transform.localScale = new Vector3(startDir.x * Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
    }

    bool checkEnd()
    {
        RaycastHit2D[] raycastHit;
        
        raycastHit = Physics2D.RaycastAll(new Vector2(rigid2D.position.x + startDir.x, rigid2D.position.y), Vector2.down, 1);
        Debug.DrawRay(new Vector2(rigid2D.position.x + startDir.x, rigid2D.position.y), Vector2.down, Color.green);
        bool something = true;
        for (int i = 0; i < raycastHit.Length && something; i++)
        {
            if (raycastHit[i] && raycastHit[i].transform.tag != "Player")
            {
                something = false;
            }
        }
        return something;
    }

    bool checkWall()
    {
        RaycastHit2D[] raycastHit;
        raycastHit = Physics2D.RaycastAll(transform.position, startDir, 1);
        Debug.DrawRay(transform.position, startDir, Color.black);
        bool something = false;
        for (int i = 0; i < raycastHit.Length && !something; i++)
        {
            if (raycastHit[i] && raycastHit[i].transform != transform && (raycastHit[i].transform.tag == "Ground" || raycastHit[i].transform.tag == "Enemy"))
            {
                something = true;
            }
        }
        return something;
    }

    void animations()
    {
        
    }



}

