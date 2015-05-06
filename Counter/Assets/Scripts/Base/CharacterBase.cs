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
	// 武器
	protected GameObject[] weaponRack = new GameObject[2];
	// ショット
	private bool shotFlag;
	// セカンダリショット
	private bool subShotFlag;
	// ブースト
	private bool boostFlag;
	// 必殺技(ボム)
	private bool exWeaponFlag;

	// 移動 1.左右 2.上下 3.減速
	protected void Move(float ix, float iz) {
		Vector3 direction = new Vector3(ix, 0, iz).normalized;
		GetComponent<Rigidbody>().velocity = direction * speed;
	}

	// 発射入力
	protected void Shot(bool ishot, bool isubShot) {
		shotFlag 	= ishot;
		subShotFlag = isubShot;
	}

	// ブースト入力
	protected void Boost(bool iboost) {
		boostFlag = iboost;
	}

	// 必殺技入力
	protected void ExWeapon(bool iexWeapon) {
		exWeaponFlag = iexWeapon;
	}

	// 生死判定   1.シールド
	protected void IsDead(int ishield) {
		if (ishield < 0)
			Dead();
		if (lifeFlag != false)
			return;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Destroy(player);
	}

	// タイマー
	protected void Timer() { timer += Time.deltaTime; }

	// 生死フラグ
	protected void Dead() { lifeFlag = false; }
	protected void Revival() { lifeFlag = true; }

	// ダメージ処理
	public void SetShieldDamage(int attack) { shield -= attack; }

	// フラグ取得
	public bool GetIsLife() { return lifeFlag; }
	public bool GetIsShot() { return shotFlag; }
	public bool GetIsSubShot() { return subShotFlag; }
	public bool GetIsBoost() { return boostFlag; }
}
