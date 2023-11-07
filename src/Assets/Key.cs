using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject associatedDoor; // ドアのゲームオブジェクトをアサイン
    public bool isKeyUsed = false; // 鍵が使用されたことを記録する変数

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isKeyUsed)
        {
            // プレイヤーが鍵に触れたとき
            other.gameObject.SetActive(false);
            if (associatedDoor != null)
            {
                // プレイヤーが鍵に触れ、かつ鍵が使用されていないとき
                isKeyUsed = true; // 鍵を使用済みにマーク
                associatedDoor.SetActive(false); // 関連するドアを消す
            }
        }
    }
}
