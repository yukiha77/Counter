using UnityEngine;
using System.Collections;

public class Player : CharacterBase {
	InputManager _input;

	void Awake() {
		_input = GameObject.FindGameObjectWithTag("InputMgr").GetComponent<InputManager>();
	}

	void Update() {
		Vector3 test = new Vector3(Mathf.Sin(5), 0, 0);
		Debug.Log(test);
		Move	(_input.Horizontal,
		     	 _input.Vertical);
		Shot	(_input.Shot,
		     	 _input.SubShot);
		Boost	(_input.Boost);
		ExWeapon(_input.ExWeapon);
		IsDead  (shield);
	}
}
