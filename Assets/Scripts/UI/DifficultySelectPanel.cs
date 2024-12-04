using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelectPanel : MonoBehaviour
{
    public static DifficultySelectPanel instance;
    public Transform _difficultyContent;
    public CanvasGroup _canvasGroup;
    public List<DifficultyData> _difficultyDatas = new List<DifficultyData>();
    public TextAsset _difficultyTextAsset;

    public GameObject _difficultyPrefab;
    public Transform _difficultyList;
    public Image _difficultyAvatar;
    public TextMeshProUGUI _difficultyName;
    public TextMeshProUGUI _difficultyDescribe;

    void Awake() {
        instance = this;
        _canvasGroup = GetComponent<CanvasGroup>();

        _difficultyContent = Utils.Instance.findGameObject("DifficultyContent").transform;
        
        _difficultyTextAsset = Resources.Load<TextAsset>("Data/difficulty");
        _difficultyDatas = JsonConvert.DeserializeObject<List<DifficultyData>>(_difficultyTextAsset.text);

        _difficultyPrefab = Resources.Load<GameObject>("Prefabs/Difficulty");
        _difficultyList = Utils.Instance.findGameObject("DifficultyList").transform;

        _difficultyAvatar = Utils.Instance.findGameObject("Avatar_Difficulty").GetComponent<Image>();
        _difficultyName = Utils.Instance.findGameObject("DifficultyName").GetComponent<TextMeshProUGUI>();
        _difficultyDescribe = Utils.Instance.findGameObject("DifficultyDescribe").GetComponent<TextMeshProUGUI>();
        
    
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (DifficultyData difficultyData in _difficultyDatas)
        {
            DifficultyUI d = Instantiate(_difficultyPrefab, _difficultyList).GetComponent<DifficultyUI>();
            d.setData(difficultyData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
