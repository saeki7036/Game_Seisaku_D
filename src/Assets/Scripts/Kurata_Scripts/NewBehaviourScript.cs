using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int AllkeyCount = 0;
    private int keyCount = 0;
    public GameObject[] hasp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(keyCount);
        Debug.Log(AllkeyCount);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            AllkeyCount = AllkeyCount - 1;
        }

        // 追加
        // ポイント（keyCountの条件追加・・・＞鍵を持っていないと扉は開かない）
        if (other.CompareTag("Door") && keyCount > 0)
        {
            Destroy(hasp[keyCount-1]);
            // ポイント
            // keyCountを１減らす
            keyCount -= 1;

        }
        /*if (other.CompareTag("Door") && keyCount == 0)
        {
            other.transform.parent.gameObject.SetActive(false);
        }*/

    }
}
