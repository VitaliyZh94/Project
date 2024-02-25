using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private Image _manaBar;
    [SerializeField] private TextMeshProUGUI _manaText;
    [SerializeField] private TextMeshProUGUI _hpText;

    private Enemy _enemy;
    
    private float _curHp;

    private void OnEnable()
    {
        EventBus.OnTakeDamage += ChangeHp;
        EventBus.OnEnemyDied += Hide;
        EventBus.OnPlayerDied += Hide;
    }

    private void OnDisable()
    {
        EventBus.OnTakeDamage -= ChangeHp;
        EventBus.OnEnemyDied -= Hide;
        EventBus.OnPlayerDied -= Hide;
    }

    private void Start()
    {
        _enemy = GetComponentInParent<Enemy>();
        if (!_enemy) return;

        _curHp = _enemy.HP;
        _hpBar.fillAmount = _curHp / _enemy.HP;
        
        _manaBar.fillAmount = _enemy.Mana;
        _hpText.text = _enemy.HP.ToString();
        _manaText.text = _enemy.Mana.ToString();

    }

    private void ChangeHp(float takeDamage, Hero hero)
    {
        if (hero == _enemy)
        {
            _hpBar.fillAmount = _enemy.HP/100;
            _hpText.text = _enemy.HP.ToString();
        }
    }

    private void Hide() => 
        gameObject.SetActive(false);
}
