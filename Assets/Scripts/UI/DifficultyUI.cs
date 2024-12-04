using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DifficultyUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image _backImage;
    public Image _avatar;
    public Button _button;
    public DifficultyData _difficultyData;

    internal void setData(DifficultyData difficultyData)
    {
        _difficultyData = difficultyData;
        _avatar.sprite = Resources.Load<SpriteAtlas>("Image/UI/危险等级").GetSprite(difficultyData.name);
        SetBackColor(difficultyData.id);
        _button.onClick.AddListener(() => {
            ButtonClick();
        });

    }

    private void ButtonClick()
    {
        GameManager.instance.setDifficulty(_difficultyData);
        SceneManager.LoadScene("03-GamePlay");
    }

    void Awake() {
        _backImage = GetComponent<Image>();
        _avatar = transform.GetChild(0).GetComponent<Image>();
        _button = GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _backImage.color = new Color(207/255f, 207/255f, 207/255f);
        RenewDifficultyUI(_difficultyData);
    }

    private void RenewDifficultyUI(DifficultyData difficultyData)
    {
        // 刷新panel上的ui
        DifficultySelectPanel.instance._difficultyAvatar.sprite = _avatar.sprite;
        DifficultySelectPanel.instance._difficultyName.text = difficultyData.name;
        DifficultySelectPanel.instance._difficultyDescribe.text = GetDifficultyDescribe();
    }

    private string GetDifficultyDescribe()
    {
        string result = "";
        foreach (DifficultyData d in DifficultySelectPanel.instance._difficultyDatas)
        {
            if (_difficultyData.id == 1) {
                result = "无修改";
                break;
            }
            if (d.id != 1) {
                result += d.describe + "\n";
                if (d == _difficultyData) {
                    break;
                }
            }
        }
        return result;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetBackColor(_difficultyData.id);
    }

    private void SetBackColor(int id)
    {
        switch (id)
        {
            case 1:
                _backImage.color = new Color(33/255f,33/255f,33/255f);
                break;
            case 2:
                _backImage.color = new Color(63/255f,88/255f,104/255f);
                break;
            case 3:
                _backImage.color = new Color(83/255f,62/255f,103/255f);
                break;
            case 4:
                _backImage.color = new Color(103/255f,54/255f,54/255f);
                break;
            case 5:
                _backImage.color = new Color(103/255f,69/255f,54/255f);
                break;
            case 6:
                _backImage.color = new Color(91/255f,87/255f,55/255f);
                break;
            default:
                _backImage.color = new Color(33/255f,33/255f,33/255f);
                break;
        }
    }
}
