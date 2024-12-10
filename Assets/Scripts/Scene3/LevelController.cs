using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public float waveTimer;

    public GameObject _failPanel;
    public GameObject _successPanel;
    public GameObject _enemy1_Prefab;
    public GameObject _enemy2_Prefab;
    public GameObject _enemy3_Prefab;
    public GameObject _enemy4_Prefab;
    public GameObject _enemy5_Prefab;

    public GameObject _redCross_Prefab;
    public List<EnemyBase> enemy_list = new List<EnemyBase>();
    public Transform map;
    public Transform enemy_parent;
    private TextAsset levelTextAsset;
    private List<LevelData> levelDatas = new List<LevelData>();
    private LevelData currentLevelData;

    public Dictionary<String, GameObject> enemyPrefabsDic = new Dictionary<string, GameObject>();


    void Awake() {
        instance = this;
        _failPanel = Utils.Instance.findGameObject("FailPanel");
        _successPanel = Utils.Instance.findGameObject("SuccessPanel");
        _enemy1_Prefab = Resources.Load<GameObject>("Prefabs/Enemy_1");
        _enemy2_Prefab = Resources.Load<GameObject>("Prefabs/Enemy_2");
        _enemy3_Prefab = Resources.Load<GameObject>("Prefabs/Enemy_3");
        _enemy4_Prefab = Resources.Load<GameObject>("Prefabs/Enemy_4");
        _enemy5_Prefab = Resources.Load<GameObject>("Prefabs/Enemy_5");

        map = Utils.Instance.findGameObject("Map").transform;
        enemy_parent = Utils.Instance.findGameObject("Enemies").transform;
        _redCross_Prefab = Resources.Load<GameObject>("Prefabs/RedCross");
        levelTextAsset = Resources.Load<TextAsset>("Data/level0");
        levelDatas = JsonConvert.DeserializeObject<List<LevelData>>(levelTextAsset.text);
    
        enemyPrefabsDic.Add("enemy1",_enemy1_Prefab);
        enemyPrefabsDic.Add("enemy2",_enemy2_Prefab);
        enemyPrefabsDic.Add("enemy3",_enemy3_Prefab);
        enemyPrefabsDic.Add("enemy4",_enemy4_Prefab);
        enemyPrefabsDic.Add("enemy5",_enemy5_Prefab);

    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevelData = levelDatas[GameManager.instance.currentWave - 1];
        waveTimer = currentLevelData.waveTimer;

        GenerateEnemy();
    }

    private void GenerateEnemy()
    {
        foreach(WaveData enemyData in currentLevelData.enemys) {
            // 一波生成多个敌人
            for (int i=0; i< enemyData.count; i++) {
                StartCoroutine(SpawnEnemy(enemyData));
            }
        }
        
    }

    IEnumerator SpawnEnemy(WaveData enemyData)
    {
        yield return new WaitForSeconds(enemyData.timeAxis);

        if (waveTimer >=0 && !Player.instance.isDead) {
            Bounds bounds = map.GetComponent<SpriteRenderer>().bounds;
            Vector3 spawnPoint = GetRandomPoint(bounds);
            GameObject redCross = Instantiate(_redCross_Prefab, spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            Destroy(redCross);

            if (waveTimer >=0 && !Player.instance.isDead) {
                EnemyBase enemy = Instantiate(enemyPrefabsDic[enemyData.enemyName],spawnPoint,Quaternion.identity,enemy_parent).GetComponent<EnemyBase>();
                enemy_list.Add(enemy);
            }
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
        int currentWaveLevel = Player.instance.playerProp.level;
        _successPanel.GetComponent<CanvasGroup>().alpha = 1;
        SuccessPanel.instance.UpdatePanelAfterSuccess(currentWaveLevel);

        for (int i=0; i< enemy_list.Count; i++) {
            if (enemy_list[i] != null) {
                enemy_list[i].Vanish();
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
