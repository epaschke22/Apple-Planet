using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI mainScore;
    [SerializeField] private TextMeshProUGUI timeBonusScore;
    [SerializeField] private TextMeshProUGUI healthBonusScore;
    [SerializeField] private TextMeshProUGUI finalScore;

    [SerializeField] private PlayerHealth playerHealth;

    private int mainScoreValue = 0;
    private int intialTimeScore = 1000000;
    private int timeBonusScoreValue;
    private int healthBonusScoreValue;
    private int finalScoreValue;

    public void IncreaseScore(int value)
	{
        mainScoreValue += value;
        mainScore.text = "Score: " + mainScoreValue;
    }

    public void CalculateFinalScore()
	{
        timeBonusScoreValue = intialTimeScore / (Mathf.RoundToInt(Time.time) + 1);
        healthBonusScoreValue = Mathf.FloorToInt(playerHealth.health * 100);

        timeBonusScore.text = "Time Bonus: " + timeBonusScoreValue;
        healthBonusScore.text = "Heath Bonus: " + healthBonusScoreValue;

        finalScoreValue = mainScoreValue + timeBonusScoreValue + healthBonusScoreValue;
        finalScore.text = "Total Score: " + finalScoreValue;
    }
}
