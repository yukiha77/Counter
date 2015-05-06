using UnityEngine;
using System.Collections;

public class BeamBullet : WeaponBase {
	Player _player;

	void Awake() {
		user	   = GameObject.FindGameObjectWithTag("Player");
		_player	   = user.GetComponent<Player>();
		weaponType = this.gameObject;
	}

	void Update() {
		Shot(_player.GetIsShot());
		Move(pattern);
	}
}
