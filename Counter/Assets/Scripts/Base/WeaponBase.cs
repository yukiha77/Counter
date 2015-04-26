using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour {
	// 威力
	[SerializeField]
	protected int damage;
	// 速度
	[SerializeField]
	protected int speed;
	// レベル
	protected int level;
	// 経験値
	protected int exp;
	// 使用する装備
	[SerializeField]
	protected int useWeapon;
	// ショットのパターン
	[SerializeField]
	protected int pattern;
	// Wayの数
	protected int way;
	// ファイアレート
	[SerializeField]
	protected float waitTimer;
	// 装備使用機体
	protected GameObject user;
	// 弾の種類
	protected GameObject[] weaponType;
	// タイマー
	private float timer;

	// 装備の使用   1.ショットフラグ
	protected void Shot(bool ishot) {
		if (!ishot)
			return;

		Timer();
		if (timer > waitTimer) {
			WeaponGenerator(user, useWeapon);
			timer = 0;
		}
	}

	// それぞれの装備の挙動	   1.移動パターン
	protected void Move(int pattern) {
		switch (pattern) {
		case 1:
			WayShot(way);
			break;
		}
	}

	// ウェイショット   1.way数
	void WayShot(int way) {
		Vector3 direction;
		switch (way) {
		case 1:
			direction = transform.forward;
			GetComponent<Rigidbody>().velocity = direction * speed;
			break;
		}
	}

	// 装備生成   1.オブジェクト 2.弾の種類
	void WeaponGenerator(GameObject user, int type) {
		// 銃口
		Vector3 muzzle;
		// 対象のゲームオブジェクト名
		switch (user.gameObject.name) {
		case "Player":
			user = GameObject.FindGameObjectWithTag("Player");
			muzzle = new Vector3(user.transform.position.x, 0, user.transform.position.z + 1);
			if (weaponType[type].gameObject.tag == "Blade")
				muzzle = new Vector3(user.transform.position.x, 0, user.transform.position.z);
			GameObject weapon = (GameObject)Instantiate(weaponType[type], muzzle, weaponType[type].transform.rotation);
			// (Clone)対策
			weapon.name = weaponType[type].name;
			break;
		}
	}


	// タイマー
	protected void Timer() { timer += Time.deltaTime; }

	// 経験値獲得
	public void WeaponExp(int wexp) { exp += wexp; }

	// レベルアップ
	public void WeaponLevelUp() { level++; exp = 0; }

	// 外部からのレベル参照
	public int GetWeaponLevel() { return level; }
}
