using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject bullet;
	public GameObject shootPosition;
	public float shootSpeed = 1000f;
	public int playerHP = 3;

	/// <summary>
	/// ハコスコ/Google Cardboard のみ必要な処理（Gear VR の場合は不要）
	/// </summary>
	void Start() {
//		shootPosition.transform.parent = transform.FindChild ("Main Camera Left");
	}

	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			// Bullet のゲームオブジェクトを生成する
			GameObject bulletInstance = Instantiate<GameObject>(bullet);
			// 生成した Bullet の位置を shootPosition に合わせる
			bulletInstance.transform.position = shootPosition.transform.position;
			bulletInstance.GetComponent<Rigidbody> ().AddForce (shootPosition.transform.forward  * shootSpeed);
		}
	}
}
