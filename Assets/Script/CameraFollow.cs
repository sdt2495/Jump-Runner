using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("ターゲット設定")]
    [SerializeField] private Transform target; // 追従対象（Player）

    [Header("カメラオフセット")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 3f, -6f);
    // プレイヤーをどの位置から見るか（相対位置）

    [Header("追従速度")]
    [SerializeField] private float followSpeed = 5f;
    // カメラがターゲットへ追いつく速度

    private void LateUpdate()
    {
        // target が存在しない場合は何もしない
        if (target == null)
        {
            return;
        }

        // 目標位置 = プレイヤー位置 + オフセット
        Vector3 targetPos = target.position + offset;

        // カメラをスムーズに追従させる（補間処理）
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);
    }
}
