using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour {
	// シールド
	[SerializeField]
	protected int shield;
	// 機体の速度
	[SerializeField]
	protected int speed;
	// 生死
	protected bool life = true;

	// 移動 1.左右 2.上下 3.減速
	protected void Move(float ix, float iz) {
		Vector3 direction = new Vector3(ix, 0, iz).normalized;
		GetComponent<Rigidbody>().velocity = direction * speed;
	}

	protected void Weapon(bool ishot, bool iblade) {
	}

	protected void IsDead(int shield) {
		if (shield < 0)
			life = false;
	}

	public bool GetLife(bool ilife) {return life;}
}
