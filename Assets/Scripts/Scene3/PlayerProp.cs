using System;
using UnityEngine;
// 角色增强属性，显示在角色面板中，角色固有属性需要另外一个值。
// 武器或道具会影响这些属性，并且会显示在角色面板的ui中。
public class PlayerProp {
    public event Action<string, object> OnPropertyChanged;
    private int _level = 0;
    public int level {
        get {return _level;}
        set {
            if (_level != value) {
                _level = value;
                OnPropertyChanged?.Invoke(nameof(level), value);    
            }
            }
    }
    private float _exp = 0;
    public float exp {
        get {return _exp;}
        set {_exp = value;}
    }
    private float _maxHp = 10;
    public float maxHp {
        get {return _maxHp;}
        set {
            if (_maxHp != value) {
                _maxHp = value;
                OnPropertyChanged?.Invoke(nameof(maxHp), value);
            }
            }
    }
    private float _lifeRegen = 0;
    public float lifeRegen {
        get {return _lifeRegen;}
        set {
            if (_lifeRegen != value) {
                _lifeRegen = value;
                OnPropertyChanged?.Invoke(nameof(lifeRegen), value);    
            }
            }
    }
    private float _lifeStealPercent = 0;
    public float lifeStealPercent {
        get {return _lifeStealPercent;}
        set {
            if (_lifeStealPercent != value) {
                _lifeStealPercent = value;
                OnPropertyChanged?.Invoke(nameof(lifeStealPercent), value);    
            }
            }
    }
    private float _damagePercent = 0;
    public float damagePercent {
        get {return _damagePercent;}
        set {
            if (_damagePercent != value) {
                _damagePercent = value;
                OnPropertyChanged?.Invoke(nameof(damagePercent), value);    
            }
            }
    }
    private float _shortDamage = 0;
    public float shortDamage {
        get {return _shortDamage;}
        set {
            if (_shortDamage != value) {
                _shortDamage = value;
                OnPropertyChanged?.Invoke(nameof(shortDamage), value);    
            }
            }
    }
    private float _longDamage = 0;
    public float longDamage {
        get {return _longDamage;}
        set {
            if (_longDamage != value) {
                _longDamage = value;
                OnPropertyChanged?.Invoke(nameof(longDamage), value);    
            }
            }
    }
    private float _elementDamage = 0;
    public float elementDamage {
        get {return _elementDamage;}
        set {
            if (_elementDamage != value) {
                _elementDamage = value;
                OnPropertyChanged?.Invoke(nameof(elementDamage), value);    
            }
            }
    }
    private float _attackSpeedPercent = 0;
    public float attackSpeedPercent {
        get {return _attackSpeedPercent;}
        set {
            if (_attackSpeedPercent != value) {
                _attackSpeedPercent = value;
                OnPropertyChanged?.Invoke(nameof(attackSpeedPercent), value);    
            }
            }
    }
    private float _criticalRate = 0;
    public float criticalRate {
        get {return _criticalRate;}
        set {
            if (_criticalRate != value) {
                _criticalRate = value;
                OnPropertyChanged?.Invoke(nameof(criticalRate), value);    
            }
            }
    }
    private float _engineering = 0;
    public float engineering {
        get {return _engineering;}
        set {
            if (_engineering != value ) {
                _engineering = value;
                OnPropertyChanged?.Invoke(nameof(engineering), value);    
            }
            }
    }
    private float _range = 0;
    public float range {
        get {return _range;}
        set {
            if (_range != value) {
                _range = value;
                OnPropertyChanged?.Invoke(nameof(range), value);    
            }
            }
    }
    private float _armor = 0;
    public float armor {
        get {return _armor;}
        set {
            if (_armor != value) {
                _armor = value;
                OnPropertyChanged?.Invoke(nameof(armor), value);    
            }
            }
    }
    private float _evasionPercent = 0;
    public float evasionPercent {
        get {return _evasionPercent;}
        set {
            if (_evasionPercent != value) {
                _evasionPercent = value;
                OnPropertyChanged?.Invoke(nameof(evasionPercent), value);    
            }
            }
    }
    private float _speedPercent = 0;
    public float speedPercent {
        get {return _speedPercent;}
        set {
            if (_speedPercent != value) {
                _speedPercent = value;
                OnPropertyChanged?.Invoke(nameof(speedPercent), value);    
            }
            }
    }
    private float _luck = 0;
    public float luck {
        get {return _luck;}
        set {
            if (_luck != value) {
                _luck = value;
                OnPropertyChanged?.Invoke(nameof(luck), value);    
            }
            }
    }
    private float _harvest = 0;
    public float harvest {
        get {return _harvest;}
        set {
            if (_harvest != value) {
                _harvest = value;
                OnPropertyChanged?.Invoke(nameof(harvest), value);    
            }
            }
    }
}
