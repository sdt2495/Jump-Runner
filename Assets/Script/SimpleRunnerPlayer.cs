using UnityEngine;

public class SimpleRunnerPlayer : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 5f; // 左右移動速度
    [SerializeField] private float jumpForce = 6f; // ジャンプ力

    [Header("接地判定")]
    [SerializeField] private Transform groundCheck; // 足元の位置
    [SerializeField] private float groundRadius = 0.2f; // 判定半径
    [SerializeField] private LayerMask groundLayer;     // 地面レイヤー

    private Rigidbody rb;
    private bool isGrounded; // 地面の上にいるか

    private void Start()
    {
        // Rigidbodyの取得
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 左右移動（A/D または ←/→）
        float inputX = Input.GetAxisRaw("Horizontal");

        Vector3 velocity = rb.linearVelocity;
        velocity.x = inputX * moveSpeed;
        rb.linearVelocity = velocity;

        // 地面にいるか？（円判定）
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);

        // ジャンプ（スペースキー）
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // GameOver用（落下したら）
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            Debug.Log("Game Over!");
        }
    }
}
