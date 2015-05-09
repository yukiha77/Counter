using UnityEngine;
using System.Collections;

public class WeaponRack : MonoBehaviour {
	// ファイアレート
	[SerializeField]
	private float waitTime;
	// ファイアレート用タイマー
	private float rateTimer;
	// 武器
	[SerializeField]
	private GameObject[] weaponRack;
	Player _player;
	
	enum RackNum {
		NONE = -1,
		Primary,
		Secondary
	};

	void Awake() {
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void Update() {
		WeaponGenerator(this.gameObject, _player.shot, _player.subShot);
	}

	// 装備生成   1.オブジェクト
	void WeaponGenerator(GameObject user, bool shot, bool subShot) {
		// 銃口
		Vector3 muzzle;
		// 対象のゲームオブジェクト名
		switch (user.gameObject.name) {
		case "Player":
			muzzle = new Vector3(user.transform.position.x, 0, user.transform.position.z + 1);
			InstancePrimary((int)RackNum.Primary, shot, muzzle);
			InstanceSecondary((int)RackNum.Secondary, subShot, muzzle);
			break;
		}
	}
	
	void InstancePrimary(int rackNum, bool shot, Vector3 muzzle) {
		if (shot != true)
			return;
		RateTimer();
		if (rateTimer > waitTime) {
			GameObject weapon = (GameObject)Instantiate(weaponRack[rackNum], muzzle, weaponRack[rackNum].transform.rotation);
			// 弾を持ち主の子にする
			weapon.transform.parent = this.gameObject.transform;
			// (Clone)対策
			weapon.name = weaponRack[rackNum].name;
			InitializeRate();
		}
	}
	
	void InstanceSecondary(int rackNum, bool shot, Vector3 muzzle) {
		if (shot != true)
			return;
		RateTimer();
		if (rateTimer > waitTime) {
			GameObject weapon = (GameObject)Instantiate(weaponRack[rackNum], muzzle, weaponRack[rackNum].transform.rotation);
			weapon.transform.parent = this.gameObject.transform;
			weapon.name = weaponRack[rackNum].name;
			InitializeRate();
		}
	}

	// ファイアレートタイマー
	void RateTimer() { rateTimer += Time.deltaTime; }
	// レートタイマー初期化
	void InitializeRate() { rateTimer = 0; }
}
