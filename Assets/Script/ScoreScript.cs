using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] Text _comboText;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _maxScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ///まっつーのスクリプトからスコアとコンボをもらったらここに入れる
        _comboText.text = GameManager.MaxCombo.ToString();
        _scoreText.text = GameManager.TotalScore.ToString();
        _maxScoreText.text = "a";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
