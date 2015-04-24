using UnityEngine;
using System.Collections;

public class Player : CharacterBase {

	void Update() {
		Move(Input.GetAxisRaw("Horizontal"),
		     Input.GetAxisRaw("Vertical"));
	}
}
