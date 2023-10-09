using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoltergeisScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float distance = 0.8f;    // 検出可能な距離
    // Start is called before the first frame update
    void Start()
    {

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
        if (raycastHit.collider != null)
        {
            // LogにHitしたオブジェクト名を出力
            Debug.Log("HitObject : " + raycastHit.collider.gameObject.name);
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // 当たったオブジェクトが花瓶であるかを確認
                if (isHit.collider.gameObject.CompareTag("Vase"))
                {
                    // 花瓶のアニメーションを開始
                    VaseAnimation vaseAnim = raycastHit.collider.gameObject.GetComponent<VaseAnimScript>();

                    if (vaseAnim != null)
                    {
                        vaseAnim.StartAnimation();
                    }
                }

            }
        }
    }
}
