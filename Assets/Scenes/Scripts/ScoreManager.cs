using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour       //スコアを管理するクラス
{
    [SerializeField] Text _scoreText;
    float _score;
    /// <summary>_score変数の値に数値を加算するメソッド</summary>
    public void AddScore(float value)       
    {
        _score += value;
        _scoreText.text = _score.ToString();
    }
}
