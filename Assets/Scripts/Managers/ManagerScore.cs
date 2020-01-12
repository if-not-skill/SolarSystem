using UnityEngine;
using UnityEngine.UI;

public class ManagerScore : MonoBehaviour {

    private float _score = 0;
    public Text ScoreText;


    void OnEnable() {
        ManagerEvents.OnAddScore += IncreaseScoreAndUpdateUI;
    }

    void OnDisable() {
        ManagerEvents.OnAddScore -= IncreaseScoreAndUpdateUI;
    }

    private void IncreaseScoreAndUpdateUI(int score) {
        _score += score;
        ScoreText.text = _score.ToString();
    }
}