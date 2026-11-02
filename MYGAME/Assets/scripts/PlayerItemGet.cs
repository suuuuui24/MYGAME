using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerItemGet : MonoBehaviour
{
    public Slider gauge;
    public int maxCount = 5;

    private int getCount = 0;
    private GameObject targetItem;

    void Update()
    {
        // アイテムの近くでEキーを押したら
        if (targetItem != null &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            getCount++;

            // ゲージを更新
            if (gauge != null)
            {
                gauge.value = getCount;
            }

            Debug.Log("取得回数：" + getCount + "/" + maxCount);

            // 5回押したらアイテムを削除
            if (getCount >= maxCount)
            {
                Destroy(targetItem);

                targetItem = null;
                getCount = 0;

                // 今後ゲージをリセットするならば
                //if (gauge != null)
                //{
                //    gauge.value = 0;
                //}

                Debug.Log("アイテムを削除しました！");
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
