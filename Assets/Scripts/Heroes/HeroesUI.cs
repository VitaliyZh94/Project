using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HeroesUI : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Slider _manaBar;
    [SerializeField] private Image _simpleDamageImage;
    [SerializeField] private Image _skillDamageImage;
    [SerializeField] private Image _castBar;

    

    [SerializeField] private TEST _test;
    
    private Heroes _hero;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        ISkillDamage.OnStartedCast += StartFillCastBar;
    }

    private void OnDisable()
    {
        //ISkillDamage.OnStartCast -= StartFillSkillCastSlider;

        //_hero.OnTakeDamaged -= ChangeHp;
    }

    private void StartFillCastBar(float castTime)
    {
        _castBar.DOFillAmount(0, castTime);
    }

    private void StopFillCastBar()
    {
        _castBar.fillAmount = 1;
    }

    
    private void ChangeHp() => 
        _hpBar.value = _hero.HP;

    private void ChangeMana() => 
        _manaBar.value = _hero.Mana;
}
