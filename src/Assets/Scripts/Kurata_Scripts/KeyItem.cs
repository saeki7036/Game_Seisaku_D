using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string keyID; // ユニークな鍵のID
    public GameObject relatedLock; // 関連付けられた南京錠

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーが鍵を拾ったときの処理
            DoorController door = relatedLock.GetComponent<DoorController>();
            if (door != null)
            {
                door.UnlockLock();
            }

            // プレイヤーが鍵を拾った後、鍵アイテムを非表示にするか破棄するなどの処理を追加することもできます。
            gameObject.SetActive(false);
        }
    }
}
