using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Through_Wall_Script : MonoBehaviour
{
    public GameObject textObject;
    public Transform targetPosition;  // à⁄ìÆêÊÇÃà íuÇéwíËÇ∑ÇÈÇΩÇﬂÇÃTransform
    public float moveSpeed = 5.0f;    // à⁄ìÆë¨ìx

    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isMoving)
        {
            StartCoroutine(MoveToTarget());
        }
    }
    
    IEnumerator MoveToTarget()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = targetPosition.position;
        float journeyLength = Vector3.Distance(startPosition, endPosition);
        float startTime = Time.time;

        float distanceCovered = 0;
        float fractionOfJourney = 0;

        while (fractionOfJourney < 1)
        {
            float distance = (Time.time - startTime) * moveSpeed;
            fractionOfJourney = distance / journeyLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            yield return null;
        }

        isMoving = false;
    }
}
