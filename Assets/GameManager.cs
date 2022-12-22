using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // トータルスコアを渡すためのプロパティ
    public static int TotalScore { get; private set; } = 0;
    [SerializeField, Header("コンボカウントを表示するテキスト")] GameObject _comboText;
    [SerializeField, Header("スコアを表示するテキスト")] Text _scoreText;
    [SerializeField, Header("コンボ中にスコアに掛ける数")] float _multiple = 1.5f;
    [SerializeField, Header("燃料ゲージ")] Image _fuelgauge;
    // [SerializeField, Header("Playerを割り当てる")] PlayerController _playerController;
    bool _gameclear = false;
    int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _comboText.SetActive(false);
        _fuelgauge.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(int getscore, int combo)
    {
        int addscore;

        if (combo == 0)
        {
            addscore = getscore;
            _comboText.SetActive(false);
            
        }
        else if (combo % 5 == 0)
        {
            _multiple = 2;
            addscore = (int)(getscore * _multiple);
            _comboText.GetComponent<Text>().text = combo.ToString();
        }
        else
        {
            addscore = (int)(getscore * _multiple);
            _comboText.GetComponent<Text>().text = combo.ToString();
            _comboText.SetActive(true);
        }
        _scoreText.DOCounter(_score, _score + addscore, 0.5f);
        _score += addscore;
    }
}
