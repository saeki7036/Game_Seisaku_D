using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float detectDistance;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    bool IsDetected = false;

    enum Move
    {
        Escape,
        Chase,
        Search,
        Stop,
    };

    Move EnemyMove;
    GameObject Light;
    EnemyLight LIghtTrigger;
    GameObject Visbility;
    EnemyVisibility VisbilityTrigger;


    void Start()
    {
        Light = GameObject.Find("LightTrigger");
        LIghtTrigger = Light.GetComponent<EnemyLight>();

        Visbility = GameObject.Find("VisbilityTrigger");
        VisbilityTrigger = Visbility.GetComponent<EnemyVisibility>();




        EnemyMove = Move.Search;

        agent = GetComponent<NavMeshAgent>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動
       
        agent.autoBraking = false;

        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返す
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定
        destPoint++;

        if (points.Length == destPoint)
        {
            destPoint = 0;
        }
    }

    void ChangeMove()
    {
        if (LIghtTrigger.lightEnter)
        {
            EnemyMove = Move.Search;
        }
        else
        {
            EnemyMove = Move.Search;
        }
        if (VisbilityTrigger.visbilityEnter)
        {
            EnemyMove = Move.Chase;
        }
        else
        {
            EnemyMove = Move.Search;
        }







    }





    // Update is called once per frame
    void Update()
    {
        float distance = 0;
       
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectDistance)
        {
            IsDetected = true;
        }
        else
        {
            IsDetected = false;
        }
        if (!IsDetected)
        {
            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        else if (player)
        {
            agent.destination = player.transform.position;
        }
    }
}
