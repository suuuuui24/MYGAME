using UnityEngine;
using System.Collections.Generic;

public class WallSwitch : MonoBehaviour
{
    public GameObject wall;

    // 接触しているPlayerを管理するリスト
    private HashSet<Collider> players = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        // Player1またはPlayer2が接触したとき
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // 接触したPlayerをリストに追加
            players.Add(other);

            // 壁が設定されている場合
            if (wall != null)
            {
                wall.SetActive(false); // 壁を非表示にする
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Player1またはPlayer2が離れたとき
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // 離れたPlayerをリストから削除
            players.Remove(other);

            // 接触しているPlayerが0人で、壁が設定されている場合
            if (players.Count == 0 && wall != null)
            {
                wall.SetActive(true); // 壁を再表示する
            }
        }
    }
}
