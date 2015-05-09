using UnityEngine;
using System.Collections;

public class EnemyTest : CharacterBase {
	
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Bullet") {
			SetShieldDamage(1);
		}
	}
}
