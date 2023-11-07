using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoltergeisScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float distance = 0.8f;    // 検出可能な距離

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rayはカメラの位置からとばす
        var rayStartPosition = player.transform.position;
        // Rayはカメラが向いてる方向にとばす
        var rayDirection = player.transform.forward.normalized;

        // Hitしたオブジェクト格納用
        RaycastHit raycastHit;

        // Rayを飛ばす（out raycastHit でHitしたオブジェクトを取得する）
        var isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);

        // Debug.DrawRay (Vector3 start(rayを開始する位置), Vector3 dir(rayの方向と長さ), Color color(ラインの色));
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        // なにかを検出したら
        if (isHit)
        {
           // Debug.Log("A");
            // LogにHitしたオブジェクト名を出力
            Debug.Log("HitObject : " + raycastHit.collider.gameObject.name);
            if (raycastHit.collider.CompareTag("Vase"))
            {
               // Debug.Log("B");
                if (Input.GetKeyDown(KeyCode.Z))
                {
                   // Debug.Log("C");
                    var vaseRb = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
                    if (vaseRb != null)
                    {
                        vaseRb.velocity = new Vector3(1f, 0, 0);
                        //Debug.Log("aA");
                    }
                }

            }
           /* else if (raycastHit.collider.CompareTag("Hide"))
            {
               // Debug.Log("BB");
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Transform hitTransform = raycastHit.transform;
                    Debug.Log("HitObject's Transform: " + hitTransform.name);

                    BoxCollider boxCollider = raycastHit.collider.gameObject.GetComponent<BoxCollider>();
                    if (boxCollider != null)
                    {
                        boxCollider.isTrigger = true;
                    }
                    GetComponent<Playercontroller>().enabled = false;

                }
            }*/
        }
    }
}