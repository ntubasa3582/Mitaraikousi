using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ObjectMove : MonoBehaviour //オブジェクトを直線移動させるクラス
{
    ScoreManager _scoreManager;
    
    [SerializeField, Tooltip("オブジェクトの移動パラメータ"), Range(5, 10)] float _moveSpeed;
    [SerializeField] float _horizontalMoveSpeed;
    [SerializeField] GameObject _xLimit;
    Rigidbody _rb;
    Vector3 _vector;
    float _moveX;

    /// <summary>trueなら動きを止める。falseなら直線移動をする</summary>
    bool _isMoveStop;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.localPosition.x, _xLimit.transform.localPosition.x, _xLimit.transform.localPosition.x * -1), transform.position.y, transform.position.z);
        if (!_isMoveStop)
        {
            _moveX = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector3(_moveX * 10, 0, _moveSpeed * 3);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            _isMoveStop = true;
            _rb.Sleep();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Itemタグが付いたオブジェクトに触れたらスコアを加算する
            _scoreManager.AddScore(1);
            Destroy(other.gameObject);
    }
}