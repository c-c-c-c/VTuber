using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    //Unityちゃんを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;

    //前進するための力(追加)
    private float forwardForce = 800.0f;

    //左右に移動するための力（
    private float turnForce = 50.0f;

    //ジャンプするための力（
    private float upForce = 500.0f;

    //左右の移動できる範囲（
    private float movableRange = 3.4f;

    //動きを減速させる係数
    private float coefficient = 0.95f;


    //ゲーム終了の判定
    private bool isEnd = false;

    //ゲーム終了時に表示するテキスト
    private GameObject stateText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //得点
    private int score = 0;

    //左ボタン押下の判定
    private bool isLButtonDown = false;
    //右ボタン押下の判定
    private bool isRButtonDown = false;

    //左ボタン押下の判定
    private bool isLButtonUp = false;
    //右ボタン押下の判定
    private bool isRButtonUp = false;

    //ポーズの判定
    private string poseButton;

	// Use this for initialization
	void Start () {

        print("hoge");
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1.5f);

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");
        //得点のオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update () {
        //this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);
        //this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

        //ゲーム終了ならUnityちゃんの動きを減衰する
        if (this.isEnd) {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }


        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if ( (Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {
            //左に移動
            this.myRigidbody.AddForce(0, 0, this.turnForce);
            this.myAnimator.SetBool("WALKLEFT", true);
            //if (this.myAnimator.GetBool("WALKLEFT") != true ) { 
            //    this.myAnimator.SetBool("WALKLEFT", true);
            //    print("hoge");
            //}
        }
        else if (( Input.GetKey(KeyCode.RightArrow)|| this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            // 右に移動
            this.myRigidbody.AddForce(0, 0, -this.turnForce);
            this.myAnimator.SetBool("WALKRIGHT", true);
            print("walkright");
            //this.myAnimator.SetBool("WALKRIGHT", true);
            //if (this.myAnimator.GetBool("WALKRIGHT") != true) { this.myAnimator.SetBool("WALKRIGHT", true); }

        }

        //if (Input.GetKeyDown(KeyCode.LeftArrow) && this.myAnimator.GetBool("WALKLEFT") == false)
        //if (Input.GetKeyDown(KeyCode.LeftArrow) )
        //{
        //    this.myAnimator.SetBool("WALKLEFT", true);
        //    this.myAnimator.SetBool("WALKINGLEFT", true);

        //}

        //if (Input.GetKeyDown(KeyCode.RightArrow) && this.myAnimator.GetBool("WALKRIGHT") == false)
        //{
        //    this.myAnimator.SetBool("WALKRIGHT", true);
        //    this.myAnimator.SetBool("WALKINGRIGHT", true);
        //}

        //if ( (Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.RightArrow) )||
                                                     //(isLButtonDown == false) || (isRButtonDown == false) 
        if ( (Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.RightArrow) ||isLButtonUp == true || isRButtonUp == true)
           
           ) {
            this.myAnimator.SetBool("WALKLEFT", false);
            this.myAnimator.SetBool("WALKRIGHT", false);
            this.myAnimator.SetBool("WALKINGLeft", false);
            this.myAnimator.SetBool("WALKINGRIGHT", false);
            isLButtonUp = false;
            isRButtonUp = false;
        }

        //Jumpステートの場合はJumpにfalseをセットする
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //ジャンプしてないときにスペースが押されたら、ジャンプする
        //if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        //{
        //    //ジャンプアニメを再生
        //    this.myAnimator.SetBool("Jump", true);
        //    //Unityちゃんに上方向の力を加える
        //    this.myRigidbody.AddForce(this.transform.up * this.upForce);
        //}

 

        //Lボタンが押される
        if (Input.GetKeyDown(KeyCode.L) || poseButton == "L")
        {
            this.myAnimator.SetBool("LOSE00", true);
            this.poseButton = ""; 
        }
        //if (Input.GetKeyUp(KeyCode.L))
        //{
        //    this.myAnimator.SetBool("LOSE00", false);
        //}

        //Wボタンが押される
        if (Input.GetKeyDown(KeyCode.W) || poseButton == "W")
        {
            this.myAnimator.SetTrigger("WAIT02");
            this.poseButton = ""; 
        }
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    this.myAnimator.SetBool("WAIT02", false);
        //}

        //Hボタンが押される(Hello)
        if (Input.GetKeyDown(KeyCode.H) || poseButton == "H")
        {
            this.myAnimator.SetTrigger("WAIT03");
            print("came");
            this.poseButton = ""; 
        }

        //Rボタンが押される
        if (Input.GetKeyDown(KeyCode.R) )
        {
            this.myAnimator.SetTrigger("REFLESH00");
            this.poseButton = ""; 
        }

        //Vボタンが押される(Victory)
        if (Input.GetKeyDown(KeyCode.V) || poseButton == "V")
        {
            this.myAnimator.SetTrigger("WIN00");
            this.poseButton = ""; 
        }


    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    private void OnTriggerEnter(Collider other) { 
        //障害物に衝突した場合
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag") {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }

        //ゴール地点に到達した場合
        if (other.gameObject.tag == "GoalTag") {
            this.isEnd = true;
            //stateTextにGAME CLEARを表示
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }

        //コインに衝突した場合
        if (other.gameObject.tag == "CoinTag") {
            //スコアを加算
            this.score += 10;

            //ScoreText隠した点数を表示
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";

            //パーティクルを再生
            GetComponent<ParticleSystem> ().Play ();

            //接触したコインのオブジェクトを破棄
            Destroy(other.gameObject);
        }
    }


    ////ジャンプボタンを押した場合の処理（追加）
    //public void GetMyJumpButtonDown()
    //{
    //    if (this.transform.position.y < 0.5f)
    //    {
    //        this.myAnimator.SetBool("Jump", true);
    //        this.myRigidbody.AddForce(this.transform.up * this.upForce);
    //    }
    //}

    //左ボタンを押し続けた場合の処理（追加）
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理（追加）
    public void GetMyLeftButtonUp()
    {
        this.isLButtonUp = true;
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理（追加）
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理（追加）
    public void GetMyRightButtonUp()
    {
        this.isRButtonUp = true;
        this.isRButtonDown = false;
    }


    //やったーボタン
    public void GetMyPoseVictory()
    {
        this.poseButton = "V"; 
    }

    //負けたボタン
    public void GetMyPoseLose()
    {
        this.poseButton = "L";
    }

    //ハローボタン
    public void GetMyPoseHello()
    {
        this.poseButton = "H";
    }
    //るんるんwaitボタン
    public void GetMyPoseWait()
    {
        this.poseButton = "W";
     }



}