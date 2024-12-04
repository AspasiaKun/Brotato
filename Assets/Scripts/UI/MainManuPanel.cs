using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManuPanel : MonoBehaviour
{
    private Button startButton;
    private Button settingButton;
    private Button progressButton;
    private Button exitButton;

    private Button FindButton(string buttonName)
    {
        GameObject buttonObject = Utils.Instance.findGameObject(buttonName);
        Button button = buttonObject.GetComponent<Button>();
        if (button == null) {
            Debug.LogError($"Button component not found on '{buttonName}'!");
            return null;
        }
        return button;
    }
    void Awake()
    {
        startButton = FindButton("StartButton");
        settingButton = FindButton("SettingButton");
        progressButton = FindButton("ProgressButton");
        exitButton = FindButton("ExitButton");
    }
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => {
            SceneManager.LoadScene("02-LevelSelect");
            // RoleSelectPanel.instance._canvasGroup.alpha = 1;
            // RoleSelectPanel.instance._canvasGroup.interactable = true;
            // RoleSelectPanel.instance._canvasGroup.blocksRaycasts = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
