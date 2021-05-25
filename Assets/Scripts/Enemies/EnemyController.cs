using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;

    GameObject[] targetPlayers;

    Transform target;
    NavMeshAgent agent;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        targetPlayers = GameManager.instance.GetInstantiatedPlayers();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.stoppingDistance += 0.5f;
    }

    private Transform Nearest(GameObject[] players)
    {
        float minDistance = float.MaxValue;
        GameObject nearestPlayer=null;
        foreach (GameObject p in players)
        {
            
            if (p)
            {
                float dist = Vector3.Distance(p.transform.position, transform.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    nearestPlayer = p;
                }
            }
            
        }
        if (nearestPlayer == null) return null;
        return nearestPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
            //target = targetPlayers[0].transform;
            target = Nearest(GameObject.FindGameObjectsWithTag("Player"));//non posso usare targetPlayer per prendere i giocatori, perche' contiene solo il player locale
            if (target)
            {
                float distance = Vector3.Distance(target.position, transform.position);
                
                if (distance <= lookRadius && !animator.GetCurrentAnimatorStateInfo(0).IsName("GetHit") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))//vedo il player nel mio campo visivo
                {
                    agent.isStopped = false;
                    agent.SetDestination(target.position);//vado verso quella direzione

                    animator.SetBool("walk", true);
                    if (distance <= agent.stoppingDistance)//sono vicino al player
                    {
                        animator.SetBool("walk", false);
                        
                        animator.SetTrigger("attack");
                        FaceTarget();
                    }
                    else if (distance > agent.stoppingDistance)//se mi riallontano riprende a camminare
                    {
                        animator.SetBool("walk", true);
                        

                    }

                }
                else if (animator.GetCurrentAnimatorStateInfo(0).IsName("GetHit")|| animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                {
                    agent.isStopped = true;//fermo l'agente se e' stato colpito per fare l'animazione gethit

                }else if(distance>lookRadius && animator.GetBool("walk"))//se mi allontano troppo si ferma di nuovo
                {
                    animator.SetBool("walk", false);
                    agent.isStopped = true;
                }
                
            }

            
        
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
