using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	// 各種入力
	public float Horizontal  { get; private set; }
	public float Vertical 	 { get; private set; }
	public bool  Shot 		 { get; private set; }
	public bool  SubShot 	 { get; private set; }
	public bool  Boost 		 { get; private set; }
	public bool  ExWeapon 	 { get; private set; }
	
	void Update() {
		InputController(Input.GetAxisRaw   ("Horizontal"),
		                Input.GetAxisRaw   ("Vertical"),
		                Input.GetButton    ("Shot"),
		                Input.GetButton	   ("SubShot"),		       
		                Input.GetButtonDown("Boost"),
		                Input.GetButtonDown("ExWeapon"));
	}
	
	// 入力管理
	void InputController(float x, float z, bool shot, bool subShot, bool boost, bool exWeapon) {
		Horizontal	= x;
		Vertical	= z;
		Shot	 	= shot;
		SubShot  	= subShot;
		Boost 	 	= boost;
		ExWeapon 	= exWeapon;
	}
}
