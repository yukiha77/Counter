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
	// ショットのパターン
	[SerializeField]
	protected int pattern = 1;
	// Wayの数
	protected int way = 1;
	// ファイアレート
	[SerializeField]
	protected float waitTime;
	// 装備使用機体
	protected GameObject user;
	// 弾の種類
	protected GameObject weaponType;
	// タイマー
	private float timer;

	// 装備の使用   1.ショットフラグ
	protected void Shot(bool ishot) {
		if (!ishot)
			return;
		Timer();
		if (timer > waitTime) {
			WeaponGenerator(user);
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

	// 装備生成   1.オブジェクト
	void WeaponGenerator(GameObject user) {
		// 銃口
		Vector3 muzzle;
		// 対象のゲームオブジェクト名
		switch (user.gameObject.name) {
		case "Player":
			muzzle = new Vector3(user.transform.position.x, 0, user.transform.position.z + 1);
			if (weaponType.gameObject.tag == "Blade")
				muzzle = new Vector3(user.transform.position.x, 0, user.transform.position.z);
			GameObject weapon = (GameObject)Instantiate(weaponType, muzzle, weaponType.transform.rotation);
			// (Clone)対策
			weapon.name = weaponType.name;
			break;
		}
	}


	// タイマー
	protected void Timer() { timer += Time.deltaTime; }

	// 経験値獲得
	public void WeaponExp(int wexp) { exp += wexp; }

	// レベル初期化
	public void WeaponLevelZero() { level = 0; }

	// レベルアップ
	public void WeaponLevelUp() { level++; exp = 0; }

	// レベルダウン
	public void WeaponLevelDown() { level--; }

	// way数アップ
	public void WeaponWayUp() { way++; }

	// セット
	public void SetWeaponExp(int wexp) { exp = wexp; }

	// 外部取得
	public int GetWeaponExp() { return exp; }
	public int GetWeaponLevel() { return level; }
	public int GetIsWay() { return way; }
	public int GetIsPattern() { return pattern; }
}
