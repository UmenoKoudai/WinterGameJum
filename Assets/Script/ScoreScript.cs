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
        ///�܂��[�̃X�N���v�g����X�R�A�ƃR���{����������炱���ɓ����
        _comboText.text = "a";
        _scoreText.text = "a";
        _maxScoreText.text = "a";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
