using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseAnimScript : MonoBehaviour
{
    private bool isAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating)
        {
            // 花瓶を前進させる処理を実装
            // 例えば、transform.TranslateやRigidbodyを使用して移動させることができます

            // 花瓶が地面に到達したら
            if (transform.position.y <= 0.0f)
            {
                // アニメーション終了後、数秒後に花瓶を消滅させる
                Destroy(gameObject, 5.0f);
            }
        }
    }
    public void StartAnimation()
    {
        // アニメーションを開始
        isAnimating = true;
        // アニメーションを再生するためのトリガーをセット（Animatorコントローラーのトリガー名に合わせて設定）
        GetComponent<Animator>().SetTrigger("StartAnimation");
    }
}
