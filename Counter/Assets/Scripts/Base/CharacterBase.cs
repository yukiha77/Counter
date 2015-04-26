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
	[HideInInspector]
	public bool shotFlag;
	// セカンダリショット
	[HideInInspector]
	public bool subShotFlag;
	// ブースト
	[HideInInspector]
	public bool boostFlag;
	// 必殺技(ボム)
	[HideInInspector]
	public bool exWeaponFlag;

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

	protected void Timer() { timer += Time.deltaTime; }

	// 生死フラグ
	protected void Dead() { lifeFlag = false; }
	protected void Revival() { lifeFlag = true; }

	// ブーストフラグ
	protected void OnBoost() { boostFlag = true; }
	protected void OffBoost() { boostFlag = false; }

	// ダメージ処理
	public void SetShieldDamage(int attack) { shield -= attack; }

	// フラグ取得
	public bool GetIsLife(bool ilife) { return lifeFlag; }
	public bool GetIsShot(bool ishot) { return shotFlag; }
	public bool GetIsSubShot(bool ishot) { return subShotFlag; }
	public bool GetIsBoost(bool iboost) { return boostFlag; }
}
