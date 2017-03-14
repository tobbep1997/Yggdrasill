using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePicture : MonoBehaviour {

    [SerializeField]
    RawImage rawImage;

    [SerializeField]
    Texture2D sprite;

    public void ChangePicture()
    {
        rawImage.texture = sprite;
    }
}
