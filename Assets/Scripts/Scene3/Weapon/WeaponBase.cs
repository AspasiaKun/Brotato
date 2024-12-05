using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponBase: MonoBehaviour
{
    public WeaponData weaponData;

    public bool isAttacked = false; // 是否可以攻击，必须在可攻击范围内才能攻击
    public bool isCooling = false; // 是否在冷却
    public bool isAiming = true;
    public float attackTimer = 0;
    public float moveSpeed;
    public Transform enemy;
    public float originZ;

    void Awake() {
        originZ = transform.eulerAngles.z;
    }

    void Start() {

    }

    void Update() {
        if (Player.instance.isDead) {
            return;
        }
        if (isAiming){
            Aiming();
        }
        Fire();
        if (isCooling) {
            attackTimer += Time.deltaTime;
            if (attackTimer >= weaponData.cooling) {
                isCooling = false;
                attackTimer = 0;
            }
        }
    }

    private void Fire()
    {
        if (isCooling || !isAttacked) {
            return;
        }
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        isAiming = false;
        StartCoroutine(GoPosition());
        isCooling = true;
    }

    IEnumerator GoPosition()
    {
        Vector3 enemyPos = enemy.position + new Vector3(0, enemy.GetComponent<SpriteRenderer>().size.y / 2, 0);
        // 飞向敌人
        while (Vector2.Distance(transform.position, enemyPos) > 0.1f) {
            Vector3 dir = (enemyPos - transform.position).normalized;
            Vector3 moveAmount = dir * moveSpeed * Time.deltaTime;
            transform.position += moveAmount;
            yield return null;
        }

        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        // 返回
        StartCoroutine(ReturnPosition());
        
    }

    IEnumerator ReturnPosition()
    {
        while((Vector3.zero - transform.localPosition).magnitude > 0.1f) {
            Vector3 dir = (Vector3.zero - transform.localPosition).normalized;
            transform.localPosition += dir * moveSpeed * Time.deltaTime;
            yield return null;
        }
        // 回到原点后才可以重新开始瞄准
        isAiming = true;
    }

    public void Aiming() {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position,weaponData.range,LayerMask.GetMask("Enemy"));
        if (enemiesInRange.Length > 0) {
            isAttacked = true;
            // 找到距离自己最近的敌人，并且将武器指向这个敌人
            Collider2D nearestEnemy = enemiesInRange
            .OrderBy(enemy => Vector2.Distance(transform.position, enemy.transform.position))
            .First();
            enemy = nearestEnemy.transform;
            Vector2 dir = (Vector2)enemy.position - (Vector2)transform.position;
            float angleDegrees = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = 
                new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angleDegrees + originZ);

        } else {
            isAttacked = false;
            enemy = null;
            transform.eulerAngles = 
                new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, originZ);
        }
    
    }

}