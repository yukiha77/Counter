using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour {
	// 威力
	[SerializeField]
	protected int damage;
	// 速度
	[SerializeField]
	protected int speed;

	// レベル
	public int Level { get; private set; }
	// 経験値
	public int Exp	 { get; private set; }

	// それぞれの装備の挙動	   1.移動パターン
	virtual protected void Move() {
		Vector3 direction = transform.forward;
		this.GetComponent<Rigidbody>().velocity = direction * speed;
	}

	// 経験値獲得
	public void WeaponExp(int wexp) { Exp += wexp; }

	// レベル初期化
	public void WeaponLevelZero() { Level = 0; }

	// レベルアップ
	public void WeaponLevelUp() { Level++; Exp = 0; }

	// レベルダウン
	public void WeaponLevelDown() { Level--; }

	// セット
	public void SetWeaponExp(int wexp) { Exp = wexp; }
}
