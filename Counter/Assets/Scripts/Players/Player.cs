using UnityEngine;
using System.Collections;

public class Player : CharacterBase {
	GameObject input;
	InputMgr _input;

	void Awake() {
		input  = GameObject.FindGameObjectWithTag("InputMgr");
		_input = input.GetComponent<InputMgr>();
	}

	void Update() {
		Move(_input.GetInputHorizontal(),
		     _input.GetInputVertical());
		Shot(_input.GetInputShot(),
		     _input.GetInputSubShot());
		Boost(_input.GetInputBoost());
		ExWeapon(_input.GetInputExWeapon());
	}
}
