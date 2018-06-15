using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {

    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //private Vector3 unitychanFacePosition;
    //Unityちゃんとカメラの距離
    private float difference;


	// Use this for initialization
	void Start () {
        ////Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        ////Unityちゃんとカメラの位置
        this.difference = unitychan.transform.position.z - this.transform.position.z;

    
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.Alpha0)) {
            //Vector3 cameraDefaultPosition = new Vector3(); 
            //Vector3 cameraDefaultRotate = new Vector3();
            this.transform.position = new Vector3(-7.630383f, 2.75751f, 0.4276022f);
            this.transform.rotation = Quaternion.Euler(-184, 258, 180);

        }

        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.Alpha1) )
        {
            Vector3 unitychanFacePosition = unitychan.transform.position;
            unitychanFacePosition.y += 2.2f;
            //unitychanFaceTransform.Translate(0, -2 ,0);
            //Unityちゃんの位置に合わせてカメラの位置を移動
            this.transform.position = new Vector3(-3.6f, 1.8f, this.unitychan.transform.position.z - 1.1f);
            this.transform.LookAt(unitychanFacePosition);
        }


	}
}
