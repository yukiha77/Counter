using UnityEngine;
using System.Collections;

public class BeamBullet : WeaponBase {
	Player _player;

	void Awake() {
		_player	= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void Update() {
		Move();
	}

	// ヒット時の処理
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Enemy") {
			Destroy(this.gameObject);
			WeaponExp(10);
		}
	}
}
