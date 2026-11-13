
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerItemGet : MonoBehaviour
{
    public GameObject wall;
    public Slider gauge;
    public int maxCount = 5;

    private int getCount = 0;
    private GameObject targetItem;

    void Update()
    {
        // ゲージがMAXになったら壁を消す
        if (gauge != null && gauge.value >= gauge.maxValue)
        {
            if (wall != null)
            {
                Destroy(wall);
                wall = null;
                Debug.Log("ゲージMAX！壁を削除！");
            }
        }

        // アイテムの近くでEキーを押したら
        if (targetItem != null &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            getCount++;

            // ゲージを1増やす
            if (gauge != null)
            {
                gauge.value = Mathf.Min(gauge.value + 1, gauge.maxValue);
            }

            Debug.Log("取得回数：" + getCount + "/" + maxCount);

            // 5回押したらアイテムのみ削除
            if (getCount >= maxCount)
            {
                Destroy(targetItem);

                targetItem = null;
                getCount = 0;

                Debug.Log("アイテムを削除！");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            targetItem = other.gameObject;
            Debug.Log("アイテムに近づきました！");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetItem)
        {
            targetItem = null;
            Debug.Log("アイテムから離れました！");
        }
    }
}
