using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ScoreService scoreService;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text comboText;

    private void OnEnable()
    {
        scoreService.OnScoreChanged += UpdateScore;
        scoreService.OnComboChanged += UpdateCombo;
    }

    private void OnDisable()
    {
        scoreService.OnScoreChanged -= UpdateScore;
        scoreService.OnComboChanged -= UpdateCombo;
    }

    private void Start()
    {
      
        UpdateScore(scoreService.CurrentScore);
        UpdateCombo(scoreService.CurrentCombo);
    }

    private void UpdateScore(int value)
    {
        scoreText.text = $"Score: {value}";
        
    }

    private void UpdateCombo(int value)
    {
        
        comboText.gameObject.SetActive(value > 1);
        comboText.text = $"Combo x{value}";
    }
}
