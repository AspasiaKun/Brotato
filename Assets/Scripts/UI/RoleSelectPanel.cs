using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class RoleSelectPanel : MonoBehaviour
{
    public static RoleSelectPanel instance;

    public List<RoleData> roleDatas = new List<RoleData>();
    public TextAsset roleTextAsset;
    public Transform _roleList;
    public GameObject _rolePrefab;
    public TextMeshProUGUI _roleName;
    public Image _roleAvatar;
    public TextMeshProUGUI _roleDescribe;
    public TextMeshProUGUI _roleRecordDetail;
    public CanvasGroup _canvasGroup;
    public GameObject _roleDetails;
    public CanvasGroup _contentCanvasGroup;

    void Awake() {
        instance = this;

        roleTextAsset = Resources.Load<TextAsset>("Data/role");

        roleDatas = JsonConvert.DeserializeObject<List<RoleData>>(roleTextAsset.text);
        
        _roleList = Utils.Instance.findGameObject("RoleList").transform;
        _rolePrefab = Resources.Load<GameObject>("Prefabs/Role");

        _roleName = Utils.Instance.findGameObject("RoleName").GetComponent<TextMeshProUGUI>();
        _roleAvatar = Utils.Instance.findGameObject("Avatar_Role").GetComponent<Image>();
        _roleDescribe = Utils.Instance.findGameObject("RoleDiscribe").GetComponent<TextMeshProUGUI>();
        _roleRecordDetail = Utils.Instance.findGameObject("RecordDetail").GetComponent<TextMeshProUGUI>();

        _canvasGroup = GetComponent<CanvasGroup>();
        _roleDetails = Utils.Instance.findGameObject("RoleDetails");
        _contentCanvasGroup = Utils.Instance.findGameObject("RoleContent").GetComponent<CanvasGroup>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(RoleData roleData in roleDatas) {
            RoleUI r = Instantiate(_rolePrefab, _roleList).GetComponent<RoleUI>();
            r.setData(roleData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
