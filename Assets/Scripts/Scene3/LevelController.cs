using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public float waveTimer;

    public GameObject _failPanel;
    public GameObject _successPanel;
    public GameObject _enemy1_Prefab;
    public List<EnemyBase> enemy_list = new List<EnemyBase>();
    public Transform map;
    public Transform enemy_parent;

    void Awake() {
        instance = this;
        _failPanel = Utils.Instance.findGameObject("FailPanel");
        _successPanel = Utils.Instance.findGameObject("SuccessPanel");
        _enemy1_Prefab = Resources.Load<GameObject>("Prefabs/Enemy_1");

        map = Utils.Instance.findGameObject("Map").transform;
        enemy_parent = Utils.Instance.findGameObject("Enemies").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        waveTimer = 15 + 5 * GameManager.instance.currentWave;

        GenerateEnemy();
    }

    private void GenerateEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(waveTimer >=0 && !Player.instance.isDead) {
            yield return new WaitForSeconds(0.5f);
            
            Bounds bounds = map.GetComponent<SpriteRenderer>().bounds;
            Vector3 spawnPoint = GetRandomPoint(bounds);
            // 敌人重生
            EnemyBase go = Instantiate(_enemy1_Prefab, spawnPoint, Quaternion.identity, enemy_parent).GetComponent<EnemyBase>();
            enemy_list.Add(go);

        }
    }

    private Vector3 GetRandomPoint(Bounds bounds)
    {
        float saftyDistance = 3.5f;
        float randomX = UnityEngine.Random.Range(bounds.min.x + saftyDistance, bounds.max.x - saftyDistance);
        float randomY = UnityEngine.Random.Range(bounds.min.y + saftyDistance, bounds.max.y - saftyDistance);
        float randomZ = 0f;
        return new Vector3(randomX, randomY, randomZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (waveTimer > 0) {
            waveTimer -= Time.deltaTime;

            if (waveTimer <= 0) {
                waveTimer = 0;
                GameSuccess();
            }
        }
        GamePanel.instance.RenewWaveTimer(waveTimer);
    }

    public void GameSuccess() {
        _successPanel.GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(GoMenu());

        for (int i=0; i< enemy_list.Count; i++) {
            if (enemy_list[i] != null) {
                enemy_list[i].Dead(); // todo: 应该是消失
            }
        }
    }

    // 游戏失败

    public void GameFailed() {
        _failPanel.GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(GoMenu());
    }

    IEnumerator GoMenu()
    {
        // 回到主菜单
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
