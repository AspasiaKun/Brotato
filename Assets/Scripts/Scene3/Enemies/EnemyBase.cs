using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int id;
    public float hp;
    public float speed;
    public float attackInternal;
    public float damage;
    public float provideExp = 1;
    public float skillTime;
    public float range;


    // =============================
    public float attackTimer = 0;
    public bool isContact = false; // 是否接触到玩家
    public bool isCooling = false;
    public GameObject moneyPrefab;
    void Awake()
    {
        moneyPrefab = Resources.Load<GameObject>("Prefabs/Money");
    }

    // 自动移动
    public void Move() {
        Vector2 dir = (Player.instance.transform.position - transform.position).normalized;
        Vector2 result = dir * speed * Time.deltaTime;
        transform.Translate(result);
    }

    // 自动转向
    public void TurnAround() {
        // 向右看
        if (Player.instance.transform.position.x - transform.position.x >= 0.1) {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if (Player.instance.transform.position.x - transform.position.x < 0.1) {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // 攻击
    public void Attack() {
        if (isCooling == true) {
            return;
        }
        Player.instance.Injured(damage);
        isCooling = true;
        attackTimer = attackInternal;
    }

    // 受伤
    public void Injured(float attack) {
        if (hp - attack <= 0) {
            hp = 0;
            Dead();
        } else {
            hp -= attack;
        }
    }

    
    public void Dead() {
        Instantiate(moneyPrefab, transform.position, Quaternion.identity);

        Player.instance.exp += provideExp;
        GamePanel.instance.RenewMoney();
        GamePanel.instance.RenewEXP();

        Destroy(gameObject);
    }

    // 消失，用于每一波时间结束之后，怪物直接消失，不提供经验与金钱
    public void Vanish() {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.isDead){
            return;
        }
        Move();
        if (isContact && !isCooling) {
            Attack();
        }


        if (isCooling) {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0) {
                attackTimer = 0;
                isCooling = false;
            }
        }

    }

    void LateUpdate() {
        TurnAround();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isContact = true;
        }

    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isContact = false;
        }
    }
}
