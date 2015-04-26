using UnityEngine;
using System.Collections;

public class BeamBullet : WeaponBase {

	void Update() {
		Move(pattern);
	}
}
