
using UnityEngine;
using System.Collections.Generic;

public class EnemyDangerRange : MonoBehaviour
{
    [SerializeField] private float sphereSpeed = 3.0f;
    [SerializeField] private SphereCollider cautionArea;

    private readonly string[] playerTags =
    {
        "Player1",
        "Player2",
        "Player3",
        "Player4"
    };

    private readonly List<GameObject> players = new List<GameObject>();

    private GameObject target;
    private Renderer enemyRenderer;

    void Start()
    {
        enemyRenderer = GetComponent<Renderer>();

        // シーン内の4人のプレイヤーを取得
        foreach (string tag in playerTags)
        {
            GameObject[] foundPlayers = GameObject.FindGameObjectsWithTag(tag);
            players.AddRange(foundPlayers);
        }

        // 検出範囲を設定
        if (cautionArea != null)
        {
            cautionArea.isTrigger = true;
        }
    }

    void Update()
    {
        // 範囲内の最も近いプレイヤーを探す
        target = null;
        float minDistance = float.MaxValue;

        foreach (GameObject player in players)
        {
            if (player == null) continue;

            float distance = Vector3.Distance(
                transform.position,
                player.transform.position
            );

            // 検出範囲内で最も近いプレイヤーを選択
            if (cautionArea != null &&
                cautionArea.bounds.Contains(player.transform.position) &&
                distance < minDistance)
            {
                minDistance = distance;
                target = player;
            }
        }

        if (target != null)
        {
            // プレイヤーが範囲内なら赤くする
            if (enemyRenderer != null)
                enemyRenderer.material.color = Color.red;

            // プレイヤーの方向を向く（水平のみ）
            Vector3 direction = target.transform.position - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(direction);

            // プレイヤーに向かって移動
            transform.position += transform.forward
                * sphereSpeed * Time.deltaTime;
        }
        else
        {
            // 誰も範囲内にいなければ白くする
            if (enemyRenderer != null)
                enemyRenderer.material.color = Color.white;
        }
    }
}
