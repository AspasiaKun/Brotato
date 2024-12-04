using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class CommonButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private TextMeshProUGUI text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
        text.color = Color.black;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.black;
        text.color = Color.white;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (image == null)
            Debug.LogError("Image component not found on " + gameObject.name);
        if (text == null)
            Debug.LogError("TextMeshProUGUI component not found in children of " + gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
