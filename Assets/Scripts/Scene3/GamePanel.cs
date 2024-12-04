using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public static GamePanel instance;
    public Slider _hpSlider;
    public Slider _expSlider;
    public TextMeshProUGUI _money;
    public TextMeshProUGUI _grand;
    public TextMeshProUGUI _hp;
    public TextMeshProUGUI _countDown;
    public TextMeshProUGUI _waveCount;

    void Awake() {
        instance = this;
        _hpSlider = Utils.Instance.findGameObject("HpSlider").GetComponent<Slider>();
        _expSlider = Utils.Instance.findGameObject("ExpSlider").GetComponent<Slider>();
        _money = Utils.Instance.findGameObject("MoneyCount").GetComponent<TextMeshProUGUI>();
        _grand = Utils.Instance.findGameObject("ExpCount").GetComponent<TextMeshProUGUI>();
        _hp = Utils.Instance.findGameObject("HpCount").GetComponent<TextMeshProUGUI>();
        _countDown = Utils.Instance.findGameObject("CountDown").GetComponent<TextMeshProUGUI>();
        _waveCount = Utils.Instance.findGameObject("WaveCount").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RenewHP();

        RenewEXP();

        RenewMoney();

        RenewWaveCount();
    }

    public void RenewMoney()
    {
        _money.text = Player.instance.money.ToString();
    }

    public void RenewEXP()
    {
        // 每级固定经验为12
        _grand.text = "Lv. " + Player.instance.exp / 12;
        _expSlider.value = Player.instance.exp % 12 / 12;
    }

    public void RenewHP()
    {
        _hp.text = Player.instance.hp.ToString() + '/' + Player.instance.maxHp.ToString();
        _hpSlider.value = Player.instance.hp / Player.instance.maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RenewWaveTimer(float time)
    {
        _countDown.text = time.ToString("F0"); // 保留整数
    }

    public void RenewWaveCount() {
        _waveCount.text = "第 " + GameManager.instance.currentWave + " 关";
    }
}
