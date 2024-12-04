using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float _Speed = 5f;
    public Transform _playerVisual;

    public Animator _anim;
    
    public float hp = 15f;
    public bool isDead = false;
    public int money = 30;
    public float maxHp = 15f;
    public float exp = 0;
    private float _oldHorizontal = 0;
    private float _nowHorizontal = 0;
    private int _turnSign = 1;

    void Awake()
    {
        instance = this;
        _playerVisual = Utils.Instance.findGameObject("PlayerVisual").transform;
        _anim = _playerVisual.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true) {
            return;
        }
        Move();
    }

    void LateUpdate() {
        TurnAroundIfNeed();
        _oldHorizontal = _nowHorizontal;
    }
    public void Move() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // -1 0 1
        float moveVertical = Input.GetAxisRaw("Vertical");  // -1 0 1
        Vector2 moveVector = new Vector2(moveHorizontal, moveVertical);
        _nowHorizontal = moveHorizontal;

        moveVector.Normalize(); // get the direction
        transform.Translate(moveVector * _Speed * Time.deltaTime);

        if (moveVector.magnitude != 0) {
            _anim.SetBool("isMove", true);
        } else {
            _anim.SetBool("isMove", false);
        }
    }

    public void TurnAroundIfNeed() {
        if (_oldHorizontal == _nowHorizontal || _nowHorizontal == 0) {
            // do nothing
        } else if (_nowHorizontal == -1) {
            _turnSign = -1;
        } else {
            _turnSign = 1;
        }
        _playerVisual.localScale = new Vector3( _turnSign * _playerVisual.localScale.x, _playerVisual.localScale.y, _playerVisual.localScale.z);

    }

    public void Attack() {
        
    }

    public void Injured(float attack) {
        if (isDead) {
            return;
        }
        // 似了
        if (hp - attack <= 0) {
            hp = 0;
            Dead();
        }
        hp -= attack;
        GamePanel.instance.RenewHP();
    }

    public void Dead() {
        isDead = true;
        _anim.speed = 0;
        LevelController.instance.GameFailed();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Money")) {
            Destroy(other.gameObject);

            money ++;
            GamePanel.instance.RenewMoney();
        }

    }
}
