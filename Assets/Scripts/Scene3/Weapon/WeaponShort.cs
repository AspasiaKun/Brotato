using UnityEngine;

public class WeaponShort: WeaponBase{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Enemy")) {
            col.GetComponent<EnemyBase>().Injured(weaponData.damage);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
