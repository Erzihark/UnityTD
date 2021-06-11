using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class BasicMovement : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Transform target;
    public Transform CenterTarget;
    public float startingSpeed = 1.5f;


    [HideInInspector]
    public float currentSpeed;

    private bool slowed = false;

    public static bool WallTopRightDestroyed = false;
    public static bool WallBottomRightDestroyed = false;
    public static bool WallTopLeftDestroyed = false;
    public static bool WallBottomLeftDestroyed = false;

    bool Left = false;
    bool Right = false;

    bool meshTargetChanged = false;

    readonly string TagEnemyRight = "EnemyRight";
    readonly string TagEnemyLeft = "EnemyLeft";


    public void MoveTarget(Transform moveTarget)
    {
        target = moveTarget;
    }

    void Start()
    {
        currentSpeed = startingSpeed;


        if (gameObject.CompareTag(TagEnemyRight))
        {
            Right = true;
            if (WallTopRightDestroyed || WallBottomRightDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    navMeshAgent.destination = target.position;
                }
            }
        }
        else if(gameObject.CompareTag(TagEnemyLeft))
        {
            Left = true;
            if (WallTopLeftDestroyed || WallBottomLeftDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    navMeshAgent.destination = target.position;
                }
            }
        }
       
    } 
    public void Slow(float pct)
    {
        currentSpeed = startingSpeed * (1f - pct);
        slowed = true;    
    }


    void Update()
    {

        if (slowed == true)
        {
            navMeshAgent.speed = currentSpeed;

        }
        else

        {
            navMeshAgent.speed = startingSpeed;
        }

        slowed = false;

        if (meshTargetChanged)
            return;


        if (Right)
        {
            if (WallTopRightDestroyed || WallBottomRightDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
                meshTargetChanged = true;
            }
        }

        else if (Left)
        {
            if (WallTopLeftDestroyed || WallBottomLeftDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
                meshTargetChanged = true;
            }
        }        
    }
}
   
    
