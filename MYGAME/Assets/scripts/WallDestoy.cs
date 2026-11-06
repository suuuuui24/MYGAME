using UnityEngine;

public class WallDestoy : MonoBehaviour
{
    [Header("消したい壁のオブジェクト")]
    public GameObject wall;

    // プレイヤーが接触した時
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") ||
            other.CompareTag("Player2") ||
            other.CompareTag("Player3") ||
            other.CompareTag("Player4"))
        {
            Destroy(wall, 0.2f);
        }
    }
}