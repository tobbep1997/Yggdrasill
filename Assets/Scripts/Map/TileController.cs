using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class TileController : MonoBehaviour {


    [SerializeField]
    bool bGetTiles = false, bCheckDoubles = false, bcheckIfColiderIsNeeded = false, bCaclNewColiders = false;



    [SerializeField]
    bool bEnableAllColliders = false;
    [SerializeField]
    List<listWrap<TileBehavior>> tileColiders;

    


    [SerializeField]
    TileBehavior[] behavior;
    

    void Update()
    {
        getTiles();
        checkDoubles();
        checkIfColliderIsNeeded();
        //calcNewColliders();

        eneableAllColiders();
    }

    void getTiles()//Step 1: Gets all tiles 
    {
        if (!bGetTiles)        
            return;        
        behavior = FindObjectsOfType<TileBehavior>();
        bGetTiles = false;
    }

    void checkDoubles()//Step 2: Check for tiles on the same location
    {
        if (!bCheckDoubles)
            return;
        bCheckDoubles = false;

        List<TileBehavior> delete = new List<TileBehavior>();

        for (int i = 0; i < behavior.Length; i++)
        {
            for (int j = 0; j < behavior.Length; j++)
            {
                if (Mathf.Approximately(behavior[i].transform.position.x,behavior[j].transform.position.x) &&
                    Mathf.Approximately(behavior[i].transform.position.y, behavior[j].transform.position.y) && 
                    behavior[i] != behavior[j] && !delete.Contains(behavior[i]))
                {
                    if (!delete.Contains(behavior[j]))
                        delete.Add(behavior[j]);
                }
            }
        }

        this.delete(ref delete);
        bGetTiles = true;
        getTiles();
    }

    void checkIfColliderIsNeeded()//Step 3: Checks around the tile and if there are tiles all around it will disable the collider
    {
        if (!bcheckIfColiderIsNeeded)
            return;
        bcheckIfColiderIsNeeded = false;

        List<TileBehavior> removeColider = new List<TileBehavior>();

        for (int i = 0; i < behavior.Length; i++)
        { 
            int count = 0;
            for (float deg = 0; deg < Mathf.PI * 2; deg += Mathf.PI / 2)
            {
                //Debug.DrawRay(behavior[i].transform.position, new Vector2(Mathf.Cos(deg), Mathf.Sin(deg)),Color.blue);
                RaycastHit2D[] hits = Physics2D.RaycastAll(behavior[i].transform.position, new Vector2(Mathf.Cos(deg), Mathf.Sin(deg)), behavior[i].GetComponent<BoxCollider2D>().bounds.size.x);
                for (int j = 0; j < hits.Length; j++)
                {
                    if (hits[j].transform != behavior[i].transform && hits[j].transform.tag == "Ground")
                    {
                        count++;
                    }
                }
            }
            if (count == 4)
                removeColider.Add(behavior[i]);
        }
        foreach (TileBehavior item in removeColider)
        {
            item.GetComponent<BoxCollider2D>().enabled = false; 
        }
    }

    //void calcNewColliders()//Step 4: Calculates the new colliders in the scene 
    //{
    //    if (!bCaclNewColiders)
    //        return;
    //    bCaclNewColiders = false;

    //    int currentList = 0;

    //    for (int i = 0; i < behavior.Length; i++)
    //    {
    //        //tileColiders.Add(new List <TileBehavior>());
    //        List<TileBehavior> tmp = new List<TileBehavior>();
    //        getAdjesent(behavior[i], ref tmp, Vector2.left);
    //        tileColiders.Add(tmp);
    //    }

    //}

    //bool exsists(TileBehavior item)
    //{
    //    for (int i = 0; i < tileColiders.Count; i++)
    //    {
    //        if (tileColiders[i].Contains(item))
    //            return true;
    //    }
    //    return false;
    //}

    //TileBehavior next(TileBehavior behavior, Vector2 dir)
    //{
    //    for (int i = 0; i < this.behavior.Length; i++)
    //    {
    //        if (Mathf.Approximately(this.behavior[i].transform.position.x, behavior.GetComponent<Rigidbody2D>().position.x + (dir * behavior.SizeX).x) &&
    //                Mathf.Approximately(this.behavior[i].transform.position.y, behavior.GetComponent<Rigidbody2D>().position.y + (dir * behavior.SizeY).y))
    //        {
    //            return this.behavior[i];
    //        }
    //    }

    //    return null;
    //}

    //void getAdjesent(TileBehavior current, ref List<TileBehavior> list, Vector2 dir)
    //{
    //    TileBehavior tNext = next(current, dir);
    //    if (!exsists(tNext))
    //        list.Add(tNext);
    //    else
    //        return;
    //    getAdjesent(current, ref list, dir);
    //}



    void eneableAllColiders()
    {
        if (!bEnableAllColliders)
            return;
        bEnableAllColliders = false;

        for (int i = 0; i < behavior.Length; i++)
        {
            behavior[i].GetComponent<Collider2D>().enabled = true;
        }
    }

    void delete(ref List<TileBehavior> list)
    {
        TileBehavior[] delete = list.ToArray();

        for (int i = 0; i < delete.Length; i++)
        {
            DestroyImmediate(delete[i].gameObject);
        }
    }
}


public class listWrap<T>
{
    public List<T> list;

    public T this[int key]
    {
        get {
            return list[key];  
        }
    }
}