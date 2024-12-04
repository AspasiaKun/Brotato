using System.Collections;
using System.Collections.Generic;
using TMPro;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectPanel : MonoBehaviour
{
    public static WeaponSelectPanel instance;
    public CanvasGroup _canvasGroup;
    public Transform _WeaponContent;
    public List<WeaponData> _weaponDatas = new List<WeaponData>();
    public TextAsset _weaponTextAsset;
    public GameObject _weaponPrefab;
    public Transform _weaponList;
    public Image _weaponAvatar;
    public TextMeshProUGUI _weaponName;
    public TextMeshProUGUI _weaponType;
    public TextMeshProUGUI _weaponDescribe;
    public GameObject _weaponDetails;

    public CanvasGroup _weaponDetailCanvasGroup;


    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
        _canvasGroup = GetComponent<CanvasGroup>();
        _WeaponContent = Utils.Instance.findGameObject("WeaponContent").transform;
        _weaponTextAsset = Resources.Load<TextAsset>("Data/weapon");

        _weaponDatas = JsonConvert.DeserializeObject<List<WeaponData>>(_weaponTextAsset.text);

        _weaponPrefab = Resources.Load<GameObject>("Prefabs/Weapon");
        _weaponList = Utils.Instance.findGameObject("WeaponList").transform;
        _weaponAvatar = Utils.Instance.findGameObject("Avatar_Weapon").GetComponent<Image>();

        _weaponName = Utils.Instance.findGameObject("WeaponName").GetComponent<TextMeshProUGUI>();
        _weaponType = Utils.Instance.findGameObject("WeaponType").GetComponent<TextMeshProUGUI>();
        _weaponDescribe = Utils.Instance.findGameObject("WeaponDescribe").GetComponent<TextMeshProUGUI>();

        // 武器上方面板
        _weaponDetails = Utils.Instance.findGameObject("WeaponDetails");
        _weaponDetailCanvasGroup = Utils.Instance.findGameObject("WeaponDetails").GetComponent<CanvasGroup>();
    }
    void Start()
    {
        foreach(WeaponData weaponData in _weaponDatas) {
            WeaponUI w = Instantiate(_weaponPrefab, _weaponList).GetComponent<WeaponUI>();
            w.setData(weaponData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
