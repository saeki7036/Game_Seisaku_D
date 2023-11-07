using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject associatedKey; // 関連する鍵のゲームオブジェクトをアサイン

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Key keyScript = associatedKey.GetComponent<Key>();
            if (keyScript != null && keyScript.isKeyUsed)
            {
                // プレイヤーがドアに触れ、かつ鍵が使用済みである場合
                Destroy(gameObject); // ドアを消す
            }
        }
    }
}
