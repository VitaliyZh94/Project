using System.Collections;
using TMPro;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winLoseText;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        Player.OnPlayerDied += ShowLoseScreen;
        Enemy.OnEnemyDied += ShowWinScreen;
    }

    private void OnDisable()
    {
        Player.OnPlayerDied -= ShowLoseScreen;
        Enemy.OnEnemyDied -= ShowWinScreen;
    }

    private void Awake()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    private void ShowWinScreen()
    {
        _winLoseText.text = "You win!";
        StartCoroutine(ShowPanel());
    }

    private void ShowLoseScreen()
    {
        _winLoseText.text = "You lose!";
        StartCoroutine(ShowPanel());
    }

    private IEnumerator ShowPanel()
    {
        _canvasGroup.interactable = true;
        
        while (_canvasGroup.alpha <= 1 )
        {
            yield return new WaitForSeconds(0.01f);
            _canvasGroup.alpha += 0.1f;
        }
    }
}