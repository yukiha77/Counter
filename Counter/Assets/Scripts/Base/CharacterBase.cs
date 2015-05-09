using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour {
	// シールド
	[SerializeField]
	protected int shield;
	// 機体の速度
	[SerializeField]
	protected int speed;
	// 生死
	protected bool lifeFlag = true;
	// タイマー
	protected float timer;
	// ショット
	public bool shot 	 { get; private set; }
	// セカンダリショット
	public bool subShot  { get; private set; }
	// ブースト
	public bool boost 	 { get; private set; }
	// 必殺技(ボム)
	public bool exWeapon { get; private set; }

	// 移動 1.左右 2.上下 3.減速
	virtual protected void Move(float x, float z) {
		Vector3 direction = new Vector3(x, 0, z).normalized;
		GetComponent<Rigidbody>().velocity = direction * speed;
	}

	// 発射入力
	protected void Shot(bool shot, bool subShot) {
		this.shot    = shot;
		this.subShot = subShot;
	}

	// ブースト入力
	protected void Boost(bool boost) {
		this.boost = boost;
	}

	// 必殺技入力
	protected void ExWeapon(bool exWeapon) {
		this.exWeapon = exWeapon;
	}

	// 生死判定   1.シールド
	protected void IsDead(int shield) {
		if (shield < 0)
			Dead();
		if (lifeFlag != false)
			return;
		Destroy(this.gameObject);
	}

	// タイマー
	protected void Timer() { timer += Time.deltaTime; }

	// 生死フラグ
	protected void Dead()	 { lifeFlag = false; }
	protected void Revival() { lifeFlag = true; }

	// ダメージ処理
	public void SetShieldDamage(int attack) { shield -= attack; }
}
