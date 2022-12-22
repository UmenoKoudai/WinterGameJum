using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // �g�[�^���X�R�A��n�����߂̃v���p�e�B
    public static int TotalScore { get; private set; } = 0;
    [SerializeField, Header("�R���{�J�E���g��\������e�L�X�g")] GameObject _comboText;
    [SerializeField, Header("�X�R�A��\������e�L�X�g")] Text _scoreText;
    [SerializeField, Header("�R���{���ɃX�R�A�Ɋ|���鐔")] float _multiple = 1.5f;
    [SerializeField, Header("�R���Q�[�W")] Image _fuelgauge;
    // [SerializeField, Header("Player�����蓖�Ă�")] PlayerController _playerController;
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