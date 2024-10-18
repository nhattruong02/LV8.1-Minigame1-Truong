using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    private GameObject[] _listEnemy;
    private bool _isBaseAlive = true;
    private int _numberEnemy;
    private bool _isLose = false;
    [SerializeField] GameObject _finishLevel;
    [SerializeField] GameObject _losingLevel;

    public bool IsBaseAlive { private get => _isBaseAlive; set => _isBaseAlive = value; }
    public int NumberEnemy { get => _numberEnemy; set => _numberEnemy = value; }
    public bool IsLose { get => _isLose; set => _isLose = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        if( _instance == null)
            _instance = this;
    }
    void Start()
    {
        _listEnemy = GameObject.FindGameObjectsWithTag(Common.Enemy);
        _numberEnemy = _listEnemy.Length;
    }

    // Update is called once perframe
    void Update()
    {
        if (_numberEnemy == 0 && !_isBaseAlive)
        {
            _finishLevel.SetActive(true);
        }
        if(_isLose == true)
        {
            _losingLevel.SetActive(true);
        }
    }



    public void OnClickBackStartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickTryAgain()
    {
        SceneManager.LoadScene(1);
    }
}
