using UnityEngine;
using System.Collections;

public class Leech : WeaponBase {
	private float leech = 100;
	private bool leechFlag;
	private const float MAX_LEECH = 7.0f;
	private bool expFlag;

	void Update() {
		Debug.Log("Level : " + level);
		//Debug.Log("EXP : " + exp);
		LeechTrigger(exp, leech);
		BoostProc(GetIsLeech());
		LeechExpCharge(GetIsExp());
	}

	// ブーストのトリガー処理
	void LeechTrigger(int wexp, float ileech) {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Player _player	  = player.GetComponent<Player>();
		if (wexp >= 100 && _player.GetIsBoost()) {
			OnLeech();
			WeaponLevelUp();
		} else if (GetLeechParam() > MAX_LEECH) {
			InitLeech();
			OffLeech();
			WeaponLevelZero();
		}
	}
	
	// ブースト処理
	void BoostProc(bool wleech) {
		if (!wleech)
			return;
		UseLeech();
	}

	// 経験値取得処理
	void LeechExpCharge(bool expflag) {
		if (!expflag)
			return;
		WeaponExp(1);
		if (GetWeaponExp() > 100)
			SetWeaponExp(100);
	}

	// ゲージを初期化
	void InitLeech() { leech = 0; }
	// ブースト使用
	void UseLeech() { leech = Time.time; }

	// かすり判定フラグ
	void OnLeech() { leechFlag = true; }
	void OffLeech() { leechFlag = false; }

	// 経験値入手フラグ
	void OnExp() { expFlag = true; }
	void OffExp() { expFlag = false; }

	// 取得
	float GetLeechParam() { return leech; }
	bool GetIsLeech() { return leechFlag; }
	bool GetIsExp() { return expFlag; }

	// かすり判定
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Bullet")
			OnExp();
		else
			OffExp();
	}
}
