using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroesUI : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Slider _manaBar;
    [SerializeField] private Image _simpleDamageImage;
    [SerializeField] private Image _skillDamageImage;
    [SerializeField] private Image _skillCastImage;

    

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
        //_hero.OnTakeDamaged += ChangeHp;
        ISkillDamage.OnStartCast += StartFillSkillCastSlider;
    }

    private void OnDisable()
    {
        ISkillDamage.OnStartCast -= StartFillSkillCastSlider;

        //_hero.OnTakeDamaged -= ChangeHp;
    }

    private void StartFillSkillCastSlider(object sender, EventArgs e)
    {
        
    }
    //
    // private void Start()
    // {
    //     _hpBar.maxValue = _hero.HP;
    //     _hpBar.minValue = 0f;
    //
    //     _manaBar.maxValue = _hero.Mana;
    //     _hpBar.minValue = 0f;
    // }
    
    private void ChangeHp() => 
        _hpBar.value = _hero.HP;

    private void ChangeMana() => 
        _manaBar.value = _hero.Mana;
}
