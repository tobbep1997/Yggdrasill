using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerBehavior : MonoBehaviour {

    Rigidbody2D rigid2D;
    BoxCollider2D col;

    [SerializeField]
    private float jumpHight = 50, speed = 50;
    private float hight;

    private float _direction = 0;

    public float direction
    {
        get { return _direction; }
    }

    [SerializeField]
    [Range(2,5)]
    private int groundCheck = 3;
    [SerializeField]
    [Range(0,1)]
    private float exstraDistance = .1f;
    private Vector2 distanceBetweenChecks;

    [SerializeField]
    KeyCode left = KeyCode.A, right = KeyCode.D, jump = KeyCode.W;

    public bool enableControlls = true;


	void Start ()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        setHorizontalDistance(ref distanceBetweenChecks.x);
        setVerticalDistance(ref distanceBetweenChecks.y);
	}	
	void Update () {
	}
    void FixedUpdate()
    {
        if (enableControlls)
            playerMovment();
        
    }

    void playerMovment()
    {
  
        if (Input.GetKey(jump) && isGrounded())
        {
            rigid2D.AddForce(Vector2.up * jumpHight);
        }

        if (Input.GetKey(jump) && Input.GetKey(left) && !Input.GetKey(right) && onWall(Vector2.left) && !isGrounded())
        {
            rigid2D.velocity = rigid2D.velocity.normalized;
            rigid2D.AddForce((Vector2.up + Vector2.right) * jumpHight);
        }
        if (Input.GetKey(jump) && !Input.GetKey(left) && Input.GetKey(right) && onWall(Vector2.right) && !isGrounded())
        {
            rigid2D.velocity = rigid2D.velocity.normalized;
            rigid2D.AddForce((Vector2.up + Vector2.left) * jumpHight);
        }


        if (Input.GetKey(left) && !Input.GetKey(right))
        {
            rigid2D.AddForce(Vector2.left * speed * Time.deltaTime);
            _direction = -1;
        }
        else if (!Input.GetKey(left) && Input.GetKey(right))
        {
            rigid2D.AddForce(Vector2.right * speed * Time.deltaTime);
            _direction = 1;
        }
    }

    bool isGrounded()
    {
        bool grouned = false;

        for (int i = 0; i < groundCheck && !grouned; i++)
        {

            Vector2 position = new Vector2((rigid2D.position.x - col.bounds.extents.x) + (distanceBetweenChecks.x * i), rigid2D.position.y);            
            RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.down, col.bounds.extents.y + exstraDistance);          
            for (int j = 0; j < hits.Length && !grouned; j++)
            {
                if (hits[j] && hits[j].transform.tag == "Ground")
                {
                    grouned = true;
                }
            }
            
        }
        return grouned;
    }
    bool onWall(Vector2 dir)
    {
        bool onWall = false;

        for (int i = 0; i < groundCheck && !onWall; i++)
        {
            Vector2 position = new Vector2(rigid2D.position.x, (rigid2D.position.y - col.bounds.extents.x) + (distanceBetweenChecks.y * i));
            RaycastHit2D[] hits = Physics2D.RaycastAll(position, dir, col.bounds.extents.x + exstraDistance);
            for (int j = 0; j < hits.Length && !onWall; j++)
            {
                if (hits[j] && hits[j].transform.tag == "Ground")
                {
                    onWall = true;
                }
            }
        }
        return onWall;
    }

    private  void setHorizontalDistance(ref float distance)
    {
        distance = (col.bounds.extents.x * 2) / (groundCheck - 1);
    }
    private void setVerticalDistance(ref float distance)
    {
        distance = (col.bounds.extents.y * 2) / (groundCheck - 1);
    }
}
