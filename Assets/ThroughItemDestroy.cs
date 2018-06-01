using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughItemDestroy : MonoBehaviour {

    private GameObject unitychan;
    private float unitychan_pos; 

	// Use this for initialization
	void Start () {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

	}
	
	// Update is called once per frame
	void Update () {
        this.unitychan_pos = this.unitychan.transform.position.z;

        if (this.unitychan_pos > this.transform.position.z + 5) {
            Destroy(this.gameObject);
        }
	}
}
