using UnityEngine;

public class ObjectMove : MonoBehaviour     //オブジェクトを直線移動させるクラス
{
    [SerializeField,Tooltip("オブジェクトの移動パラメータ"),Range(5,10)] float _moveSpeed;
    Rigidbody _rb;
    /// <summary>trueなら動きを止める。falseなら直線移動をする</summary>
    bool _isMoveStop;
    void Awake()
    {
         _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (!_isMoveStop)
        {
            _rb.velocity = new Vector3(0, 0, _moveSpeed * 10);   
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
}
