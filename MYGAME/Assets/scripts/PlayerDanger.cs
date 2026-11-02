
using UnityEngine;

public class PlayerDanger : MonoBehaviour
{
    private bool dangerzone;

    void OnTriggerStay(Collider other)
    {
        // オブジェクト名で検出範囲を判定
        if (other.gameObject.name == "CautionArea")
        {
            dangerzone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 検出範囲から出た場合
        if (other.gameObject.name == "CautionArea")
        {
            dangerzone = false;
        }
    }
}
