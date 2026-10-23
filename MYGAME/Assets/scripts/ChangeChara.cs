using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ChangeChara : MonoBehaviour
{
    // 現在操作しているキャラクターの番号
    private int nowChara = 0;

    // 操作対象のキャラクター一覧
    [SerializeField] private List<GameObject> charaList;

    void Start()
    {
        // キャラクターが登録されているか確認
        if (charaList == null || charaList.Count == 0)
        {
            Debug.LogError("Chara Listにキャラクターを登録してください。");
            return;
        }

        // 最初に全キャラクターを操作不可にする
        foreach (GameObject chara in charaList)
        {
            PlayerMove move = chara.GetComponent<PlayerMove>();

            if (move != null)
            {
                move.ChangeControl(false);
            }
            else
            {
                Debug.LogError(
                    chara.name + " に PlayerMove がありません。"
                );
            }
        }

        // 0番目のキャラクターを操作可能にする
        PlayerMove firstMove =
            charaList[0].GetComponent<PlayerMove>();

        if (firstMove != null)
        {
            firstMove.ChangeControl(true);
        }
    }

    void Update()
    {
        // 新しい Input System でQキーを検出
        if (Keyboard.current != null &&
            Keyboard.current.qKey.wasPressedThisFrame)
        {
            ChangeCharacter();
        }
    }

    // 操作キャラクターを切り替える
    void ChangeCharacter()
    {
        if (charaList == null || charaList.Count == 0)
        {
            return;
        }

        // 現在のキャラクターを操作不可にする
        PlayerMove currentMove =
            charaList[nowChara].GetComponent<PlayerMove>();

        if (currentMove != null)
        {
            currentMove.ChangeControl(false);
        }

        // 次のキャラクター番号に進む
        nowChara = (nowChara + 1) % charaList.Count;

        // 次のキャラクターを操作可能にする
        PlayerMove nextMove =
            charaList[nowChara].GetComponent<PlayerMove>();

        if (nextMove != null)
        {
            nextMove.ChangeControl(true);
        }
    }
}