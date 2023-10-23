using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour
{
    public GameObject textObject;
    public Transform inSidePoint;
    public Transform outSidePoint;
    public float moveSpeed = 5.0f;

    private Playercontroller playerController;
    private BoxCollider boxCollider;
    private Transform nowPoint;
    private bool isPlayerInside = false;
    private bool hideMode = false;

    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInside)
        {
            // プレイヤーがエリア内にいる場合の処理
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ToggleHideMode();
            }
           
        }
    }

    void ToggleHideMode()
    {
        hideMode = !hideMode;

        if (playerController != null)
        {
            playerController.enabled = !hideMode;
        }

        if (boxCollider != null)
        {
            boxCollider.isTrigger = hideMode;
        }

        if (hideMode)
        {
            MoveToTarget(nowPoint.position, inSidePoint.position);
        }
        else
        {
            nowPoint.LookAt(outSidePoint);
            MoveToTarget(nowPoint.position, outSidePoint.position);
        }
    }

    void MoveToTarget(Vector3 nowPosition, Vector3 targetPosition)//(現在地、目的地)
    {
        // 指定の位置に向かって移動
        transform.position = Vector3.Lerp(nowPosition, targetPosition, moveSpeed);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Hide")
        {
            Transform parentTransform = col.transform.parent;
            boxCollider = parentTransform.GetComponent<BoxCollider>();
            playerController = GetComponent<Playercontroller>();
            isPlayerInside = true;
            textObject.SetActive(true);
            outSidePoint = col.transform.GetChild(0);
            inSidePoint = col.transform.GetChild(1);
            nowPoint = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInside = false;
        textObject.SetActive(false);
    }
}
