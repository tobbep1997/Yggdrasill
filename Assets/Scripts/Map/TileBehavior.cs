using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ExecuteInEditMode]
public class TileBehavior : MonoBehaviour {

    static int TILE_LAYER = 2;

    [SerializeField]
    [Header("Size")]
    [Range(0,1)]
    private float sizeX, sizeY;

    public float SizeX
    {
        get { return sizeX; }
    }

    public float SizeY
    {
        get { return sizeY; }
    }

    public enum DIRECTION { vertical, horizontal}

    void Update()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x) * sizeX, Mathf.RoundToInt(transform.position.y) * sizeY, -TILE_LAYER);
    }
}
