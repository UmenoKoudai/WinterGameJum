using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] Transform[] _playerPosition;　//移動するレーン
    [SerializeField] public float _fuel;　//Playerの体力
    [SerializeField] float _gas; //ガソリン消費量
    [SerializeField] float _moveSpeed; //　Playerの移動速度
    float _pos0; //Position0の保存
    float _pos1; //Position1の保存
    float _pos2; //Position2の保存
    [SerializeField] GameObject[] _players; // Playerの選択
    int _comboCount; // comboの数
    bool _timeStart = false; //　comboのStart
    float _timer; // 時間の計測
    [SerializeField]float _overTime; // comboが途切れるまでの制限時間
    [SerializeField] int _score; //加算するscore
    public int _playerId; //playerのID
    GameManager _gm;
    [SerializeField] float _heal; //回復量
    Animator _anim;
    [SerializeField] string _name;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pos0 = _playerPosition[0].transform.position.y;
        _pos1 = _playerPosition[1].transform.position.y;
        _pos2 = _playerPosition[2].transform.position.y;
        this.transform.position = _playerPosition[1].transform.position; //初期位置へ移動
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
    void PlayerMove()　//レーン間の移動
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
