using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int enemyHP = 1;
	public int enemyAttack = 1;
	public float enemySpeed = 1;
	public Animator anim;

	private Player player;

	void Start () {
		// プレイヤーゲームオブジェクトを探し、Playerコンポーネント（クラス）をメンバ変数に格納する
		player = GameObject.Find ("Main Camera").GetComponent<Player> ();
	}
	
	void Update () {
		// プレイヤーの方を向く
		transform.LookAt (player.transform);
		// 自分の前方（forward）へ移動する
		transform.Translate (transform.forward * enemySpeed, Space.World);
	}

	void OnCollisionEnter(Collision collision) {

		GameObject collisionTarget = collision.gameObject;

		if (collisionTarget.name.Contains ("Main Camera")) {
			// 行動を停止
			Stop ();
			// 攻撃ステート開始
			anim.SetTrigger("Attack");
		}
		else if(collisionTarget.name.Contains("Bullet"))
		{
			// 自身のコライダを無効
			gameObject.GetComponent<Collider>().enabled = false;
			// 行動を停止
			Stop ();
			// 撃破ステート開始
			anim.SetTrigger ("Left Fall");
		}
	}

	void Stop(){
		// 移動を停止 & Rigidbodyを無効
		enemySpeed = 0;
		gameObject.GetComponent<Rigidbody> ().isKinematic = true;
	}

	public void OnFinishedAttack() {
		// 自身のコライダを無効
		gameObject.GetComponent<Collider>().enabled = false;
		// プレイヤーの HP を攻撃力分減らす
		player.playerHP -= enemyAttack;
	}

	public void OnFinishedFall() {
		// 自身(エネミー)を Scene 上から削除
		Destroy (gameObject);
	}
}