using UnityEngine;
using System.Collections;

public class InputMgr : MonoBehaviour {
	// 入力送信用
	private float x, z;
	// 減速、発射入力
	private bool shot, subShot, boost, exWeapon;
	
	void Update() {
		InputController(Input.GetAxisRaw("Horizontal"),
		                Input.GetAxisRaw("Vertical"),
		                Input.GetButton("Shot"),
		                Input.GetButton("SubShot"),		       
		                Input.GetButtonDown("Boost"),
		                Input.GetButtonDown("ExWeapon"));
	}
	
	// 入力管理
	void InputController(float ix, float iz, bool ishot, bool isubShot, bool iboost, bool iexWeapon) {
		x		 = ix;
		z		 = iz;
		shot	 = ishot;
		subShot  = isubShot;
		boost 	 = iboost;
		exWeapon = iexWeapon;
	}

	// 各種入力取得
	public float GetInputHorizontal() { return x; }
	public float GetInputVertical() { return z; }
	public bool GetInputShot() { return shot; }
	public bool GetInputSubShot() { return subShot; }
	public bool GetInputBoost() { return boost; }
	public bool GetInputExWeapon() { return exWeapon; }
}
