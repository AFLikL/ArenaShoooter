using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    Transform player;
    GameObject PBody;
   float attackTime;
   float PattackTime;
    float pause;
    bool startCor=false;
    int damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PattackTime = this.transform.parent.GetComponent<EnemyScript>().PattackTime;
        attackTime=PattackTime;
        damage= this.transform.parent.GetComponent<EnemyScript>().damage;
        pause=this.transform.parent.GetComponent<EnemyScript>().timePause;

    }

    // Update is called once per frame
    void Update()
    {
        Attacking();
    }
    void Attacking()
    {
        if (PBody == player.gameObject && this.transform.parent.GetComponent<EnemyScript>().pauseState ==false)
        {
            
            MinusHpE();


        }
        if (startCor == true) 
        {
            StartCoroutine(cor(pause));
           
        }
    }
    IEnumerator cor(float p) 
    {
        startCor = false;
        this.transform.parent.GetComponent<EnemyScript>().pauseState = true;
        yield return new WaitForSeconds(p);
        this.transform.parent.GetComponent<EnemyScript>().pauseState = false;
    }
    void MinusHpE()
    {
        //PattackTime -= Time.deltaTime;
        //if (PattackTime <= 0)
        //{
            //Debug.Log("какого ху€");
            //go();
            player.gameObject.GetComponent<PlayerContoll>().hp -= damage;
            if (player.gameObject.GetComponent<PlayerContoll>().hp <= 0)
            {
                //Destroy(PBody);
                SceneManager.LoadScene(4);
            }
            PattackTime = attackTime;
            startCor = true;
       // }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PBody = player.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PBody = null;
        }
    }
}
