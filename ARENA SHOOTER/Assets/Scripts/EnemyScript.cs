using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    public int hp;
    public int damage;
    public float PattackTime;
   public float StopTime;
    float attackTime;
    public int attackDist;
    public float timePause;
    public bool pauseState= false;
    public List<GameObject> Drop=new List<GameObject>();
    Transform player;
    public float LookArea;
    [SerializeField] GameObject att;
    NavMeshAgent agent;
    GameObject PBody;
    bool searcing=true;
    Animator animator;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = this.GetComponent<NavMeshAgent>();
        attackTime =  PattackTime;
        animator = this.gameObject.transform.Find("Diver").GetComponent<Animator>();
    }
    private void Update()
   {

        if (hp > 0)
        {
            seachPlayer();
            { 
            //if (agent.isStopped == false) 
            //{
            //    Debug.Log("иду");
            //}
            }
        }
        else 
        {
            StartCoroutine(DelEn());
        } 

    }
    IEnumerator DelEn()
    {
        yield return new WaitForSeconds(0.5f);
        int drop;
        drop=UnityEngine.Random.Range(0,2);
        if (drop == 1)
        {
            Instantiate(Drop[UnityEngine.Random.Range(0,Drop.Count)], this.gameObject.transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
        Debug.Log("Death");
    }

    void seachPlayer()
    {
        if (pauseState == false)
        {
            if (player.position != null)
            {

                float dis = Vector3.Distance(this.transform.position, player.position);
                if (dis <= LookArea)
                {

                    this.gameObject.transform.LookAt(player.transform.Find("Point").transform.position);
                }

                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(player.transform.Find("Point").transform.position, path);
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    animator.SetBool("isWalking",true);
                    agent.SetPath(path);
                }

                //   Attacking();
            }
        }
    }
    //void Attacking() 
    //{
    //   if (PBody != null &&PBody == player.gameObject) 
    //   {
           
    //          MinusHpE();

           
    //    }
    //}
    //IEnumerator go()
    //{
    //    agent.isStopped = true;
    //    searcing = false;
    //   yield return new WaitForSeconds(StopTime);
    //    agent.isStopped = false;
    //    searcing = true;
    //}
    //void MinusHpE()
    //{
    //    PattackTime -= Time.deltaTime;
    //    if (PattackTime <= 0)
    //    {
    //       //Debug.Log("какого ху€");
    //        //go();
    //        player.gameObject.GetComponent<PlayerContoll>().hp -= damage;
    //        if (player.gameObject.GetComponent<PlayerContoll>().hp <= 0)
    //        {
    //            Destroy(PBody);
    //        }
    //        PattackTime=attackTime;
    //    }
      
    //}
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            PBody=player.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PBody = null;
        }
    }
    /*
        public event Action DEATH;
        public int hp = 100;
        // Start is called before the first frame update
        private void OnEnable()
        {
            DEATH += Death;
        }
        private void OnDisable()
        {
            DEATH -= Death;
        }

        // Update is called once per frame

        public void Death() 
        {
            DelEn();



        }*/

}
