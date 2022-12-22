using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] Transform[] _playerPosition;�@//�ړ����郌�[��
    [SerializeField] public float _fuel;�@//Player�̗̑�
    [SerializeField] float _gas; //�K�\���������
    [SerializeField] float _moveSpeed; //�@Player�̈ړ����x
    float _pos0; //Position0�̕ۑ�
    float _pos1; //Position1�̕ۑ�
    float _pos2; //Position2�̕ۑ�
    [SerializeField] GameObject[] _players; // Player�̑I��
    int _comboCount; // combo�̐�
    bool _timeStart = false; //�@combo��Start
    float _timer; // ���Ԃ̌v��
    [SerializeField]float _overTime; // combo���r�؂��܂ł̐�������
    [SerializeField] int _score; //���Z����score
    public int _playerId; //player��ID
    GameManager _gm;
    [SerializeField] float _heal; //�񕜗�
    Animator _anim;
    [SerializeField] string _name;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pos0 = _playerPosition[0].transform.position.y;
        _pos1 = _playerPosition[1].transform.position.y;
        _pos2 = _playerPosition[2].transform.position.y;
        this.transform.position = _playerPosition[1].transform.position; //�����ʒu�ֈړ�
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        if(_timeStart == true)
        {
            _timer += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        _fuel -= _gas;
        transform.Translate(Vector3.right * _moveSpeed);
    }
    void PlayerMove()�@//���[���Ԃ̈ړ�
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(this.transform.position.y < _pos0)
            {
                this.transform.position = _playerPosition[0].transform.position;
            }
            else if(this.transform.position.y < _pos1)
            {
                this.transform.position = _playerPosition[1].transform.position;
            }
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if(this.transform.position.y < _pos1)
            {
                this.transform.position = _playerPosition[1].transform.position;
            }
            else if(this.transform.position.y > _pos2)
            {
                this.transform.position = _playerPosition[2].transform.position;
            }
        }
    }
    void PlayerSelect(int id)
    {
        for(int i = 0; i < _players.Length; i++)
        {
            _players[i].SetActive(false);
        }
        _playerId = id;
        _players[id].SetActive(true);
        _anim.Play(_name);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetMouseButtonDown(0))
        {
            _comboCount++;
            if(_comboCount >= 1 && _timeStart == false)
            {
                _timeStart = true;
                _gm.AddScore(_score, _comboCount);
            }
            if(_timer > _overTime)
            {
                _comboCount = 0;
                _timeStart = false;
            }
            else
            {
                _timer = 0;
                _gm.AddScore(_score, _comboCount);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            _fuel += _heal;
        }
    }
}
