using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour {

    [SerializeField]
    double time = 120;

    [SerializeField]
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        int min = (int)time / 60;
        int sec = (int)time % 60;

        text.text = min + ":" + sec;

       // print(min + ":" + sec);
	}
}
