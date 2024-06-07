using UnityEngine;

public class ItemGenerator : MonoBehaviour      //アイテムを生成するクラス
{
    [SerializeField,Header("アイテムのプレハブ")] GameObject _itemPrefab;
    [SerializeField,Header("スタートのポジション")] GameObject _startPos;
    [SerializeField, Header("ゴールのポジション")] GameObject _goalPos;
    float _length;
    void Start()
    {
        _length = _goalPos.transform.position.z - _startPos.transform.position.z;
        for (int i = 0; i <= (int)_length; i++)
        {
            if (i % 5 == 1 && i > 1)
            {
                Instantiate(_itemPrefab, new Vector3(0, 1, i - 1), Quaternion.identity);
            }
            
        }
    }
}
