using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScroll : MonoBehaviour
{
    [SerializeField] GameObject[] _field;
    [SerializeField] float _addPosition;
    [SerializeField] int _maxStage;
    float _nextStagePosition;
    // Start is called before the first frame update
    void Start()
    {
        int a = (int)_addPosition;
        _nextStagePosition += _addPosition;
        for (int i = 0; i < _field.Length; i++)
        {
            Instantiate(_field[i], new Vector3(_nextStagePosition, 0, 0), transform.rotation);
            _nextStagePosition += _addPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<Stage>().Length < _maxStage)
        {
            for (int i = 0; i < _field.Length; i++)
            {
                Instantiate(_field[i], new Vector3(_nextStagePosition, 0, 0), transform.rotation);
                _nextStagePosition += _addPosition;
            }
        }
    }
}
