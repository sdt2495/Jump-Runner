using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoRestart : MonoBehaviour
{
    [Header("落下判定の高さ")]
    [SerializeField] private float minY = -5f; // ここより下に落ちたら死ぬ

    private void Update()
    {
        // Y 座標が minY 以下ならリスタート
        if (transform.position.y < minY)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
