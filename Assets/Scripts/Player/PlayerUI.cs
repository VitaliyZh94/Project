using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private Image _manaBar;
    [SerializeField] private Image _skillDamageImage;
    [SerializeField] private Image _castBar;
    
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _manaText;

    private Player _player;
    
    private float _maxHp;
    private float _maxMana;

    private void OnEnable()
    {
        EventBus.OnCastStarted += StartCastBar;
        EventBus.OnDelayStarted += StartDelayIcon;
        EventBus.OnTakeDamage += ChangeHp;
    }

    private void OnDisable()
    {
        EventBus.OnCastStarted -= StartCastBar;
        EventBus.OnDelayStarted -= StartDelayIcon;
        EventBus.OnTakeDamage -= ChangeHp;
    }

    private void Awake() => 
        _player = GetComponentInParent<Player>();

    private void Start()
    {
        if (!_player) return;
        
        _maxHp = _player.HP;
        _hpBar.fillAmount = 1;
        
        _maxMana = _player.Mana;
        _manaBar.fillAmount = 1;
        
        _hpText.text = _player.HP.ToString();
        _manaText.text = _player.Mana.ToString();
    }

    private void Update()
    {
        ChangeManaBar();
    }

    private void StartDelayIcon(float delay)
    {
        _skillDamageImage.DOFillAmount(0, 0)
            .OnComplete(()=>
                _skillDamageImage.DOFillAmount(1,delay));
    }

    private void StartCastBar(float castTime)
    {
        _castBar.DOFillAmount(0, castTime)
            .OnComplete(() =>
                _castBar.DOFillAmount(1, 0));
    }

    private void ChangeHp(float takeDamage)
    {
        _hpBar.fillAmount -= takeDamage/_maxHp;
        _hpText.text = _player.HP.ToString();
    }

    private void ChangeManaBar()
    {
        _manaBar.fillAmount = _player.Mana/_maxMana;
        _manaText.text = _player.Mana.ToString("0");
    }
}