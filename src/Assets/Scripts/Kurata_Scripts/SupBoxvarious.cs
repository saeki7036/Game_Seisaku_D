using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupBoxvarious : MonoBehaviour
{
    private Animator animator;
    public float destroyDelay = 7f;
    public float Surp_Interbal = 7f;
    public float Surp_distanse = 7f;
    private float Time_Count;
    public bool SURP;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Time_Count = 0f;
        SURP = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SURP) 
        {
            Time_Count += Time.deltaTime;

            EnemyDistanseCheck();

            if (Time_Count > Surp_Interbal)
                ActivateSurpTrigger();
        }
    }
   
    void ActivateSurpTrigger()
    {
        if (animator != null && !SURP)
        {
            SURP = true;
            animator.SetTrigger("Surp");
            DestroyGameObject();
            Enemy_Surp();
        }
    }
    
    void Enemy_Surp()
    {
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //GameObject[] Behinds = GameObject.FindGameObjectsWithTag("Behind");
        //BehindArea[] Script = new BehindArea[Enemys.Length];
        
        for (int i = 0; i < Enemys.Length; i++)
        {
            //Debug.Log(Enemys[i].name);
            //Debug.Log(Vector3.Distance(Enemys[i].transform.position, this.transform.position));
            
            if (Surp_distanse > Vector3.Distance(Enemys[i].transform.position, this.transform.position))
            {
                GameObject Behind = Enemys[i].transform.Find("Collisions/Enemy/Behind").gameObject;
                BehindArea Script = Behind.GetComponent<BehindArea>();
                if (!Script.behindEnter)
                    Script.behindEnter = true;
            }
               
        }
    }

    void EnemyDistanseCheck()
    {
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemys.Length; i++)
        {
            if(Surp_distanse > Vector3.Distance(Enemys[i].transform.position, this.transform.position))
            {
                ActivateSurpTrigger(); Debug.Log("www");
                break;
            }
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject, destroyDelay);
    }
}
