using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroesUI : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Slider _manaBar;
    [SerializeField] private Image _simpleDamageImage;
    [SerializeField] private Image _skillDamageImage;
    [SerializeField] private Image _castBar;
    [SerializeField] private Text _skillDamageTimer;

 
    
    private Heroes _hero;

 


    private void OnEnable()
    {
        Skills.OnCastStarted += StartCastBar;
        Skills.OnDelayStarted += StartDelayIcon;
    }

    private void OnDisable()
    {
        Skills.OnCastStarted -= StartCastBar;
        Skills.OnDelayStarted -= StartDelayIcon;
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

    private void StopFillCastBar()
    {
        _castBar.fillAmount = 1;
    }

    
    private void ChangeHp() => 
        _hpBar.value = _hero.HP;

    private void ChangeMana() => 
        _manaBar.value = _hero.Mana;
}
