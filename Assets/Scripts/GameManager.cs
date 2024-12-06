using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public RoleData currentRoleData;
    public List<WeaponData> currentWeaponDatas;
    public DifficultyData currentDifficultyData;
    public int currentWave = 1;

    public TextAsset enemyTextAsset;
    public List<EnemyData> enemyDatas = new List<EnemyData>();


    public void Awake()
    {
        instance = this;
        enemyTextAsset = Resources.Load<TextAsset>("Data/enemy");
        enemyDatas = JsonConvert.DeserializeObject<List<EnemyData>>(enemyTextAsset.text);
        if (enemyDatas == null) {
            Debug.Log("shit!!");
        }
    }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {

    }

    internal void setDifficulty(DifficultyData difficultyData)
    {
        currentDifficultyData = difficultyData;
    }

    internal void setRoleData(RoleData roleData)
    {
        currentRoleData = roleData;
    }

    internal void setWeaponDatas(WeaponData weaponData)
    {
        currentWeaponDatas.Add(weaponData);
    }

    internal object RandomInList<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            return null;
        }
        System.Random random = new System.Random();
        int index = random.Next(0, list.Count);
        return list[index];
    }


}