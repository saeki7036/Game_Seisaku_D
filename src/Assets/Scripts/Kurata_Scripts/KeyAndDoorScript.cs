using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyAndDoorScript : MonoBehaviour
{
    public GameObject[] zyomaeLocks;

    public GameObject Door;

    public int requiredKeys = 3;

    private int collectedKeys = 0;

    private bool keysCollected = false;

    public Image[] KeyImages;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {  
            collectedKeys++;
            keysCollected = true;
            // プレイヤーの持っている鍵を削除
            Destroy(other.gameObject);
            KeyImages[collectedKeys - 1].enabled = true;
        }

        if (other.CompareTag("Door"))
        {
            // 錠前が外れる処理を実行
            UnlockDoor();

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            // すべての鍵を取得した場合、扉を開ける処理
            if (collectedKeys >= requiredKeys)
            {
                OpenDoor();
            }
        }
    }
    void UnlockDoor()
    {
        if(keysCollected)
        {
            for (int i = 0; i < collectedKeys; i++)
            {
                zyomaeLocks[i].SetActive(false);

                Rigidbody parentRigidbody = zyomaeLocks[i].transform.parent.GetComponent<Rigidbody>();
                if (parentRigidbody != null)
                {
                    parentRigidbody.isKinematic = false;
                }
            }
        }
    }

    void OpenDoor()
    {
        Destroy(Door,3f);
    }
}
