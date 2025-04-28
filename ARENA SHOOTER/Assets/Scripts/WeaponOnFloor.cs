using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOnFloor : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject PBody;
    public float Reaload;
    public int damage;
    public float AttackDistance;
    public float attackH; 
    public float attackW;
    Vector3 oldPos;
    Vector3 newPos;
   public GameObject model;
    public float Life;
    static bool change = false;
    static bool RLH = false;
    void Start()
    {
        Debug.Log("проблем");
    }

    // Update is called once per frame
    void Update()
    {
        Life-=Time.deltaTime;
        if (Life < 0) 
        {
            Destroy(this.gameObject);
        }
    }
    void changeDistance() 
    {
     
        if (this.gameObject.tag == "RL")
        {
            if (change==false)
            {
                if(RLH==false)
                {
                    RLH = true;
                    if ( PBody.GetComponent<PlayerContoll>().Rhand.transform.childCount != 0)
                    {
                        Destroy(PBody.GetComponent<PlayerContoll>().Rhand.transform.GetChild(0).gameObject);
                    }
                    PBody.GetComponent<PlayerContoll>().Rweapon = model;
                    Instantiate(PBody.GetComponent<PlayerContoll>().Rweapon, PBody.GetComponent<PlayerContoll>().Rhand.position, PBody.GetComponent<PlayerContoll>().Rhand.rotation, PBody.GetComponent<PlayerContoll>().Rhand);
                    
                }
                else 
                {
                    if (PBody.GetComponent<PlayerContoll>().Lhand.transform.childCount != 0)
                    {
                        Destroy(PBody.GetComponent<PlayerContoll>().Lhand.transform.GetChild(0).gameObject);
                    }
                    PBody.GetComponent<PlayerContoll>().Lweapon = model;
                    Instantiate(PBody.GetComponent<PlayerContoll>().Lweapon, PBody.GetComponent<PlayerContoll>().Lhand.position, PBody.GetComponent<PlayerContoll>().Lhand.rotation, PBody.GetComponent<PlayerContoll>().Lhand);
                    change = true;
                    RLH = false;

                }

            }
            else
            {
                if (PBody.GetComponent<PlayerContoll>().Rhand.transform.childCount != 0)
                {
                    Destroy(PBody.GetComponent<PlayerContoll>().Rhand.transform.GetChild(0).gameObject);
                }
                PBody.GetComponent<PlayerContoll>().Rweapon = model;
                Instantiate(PBody.GetComponent<PlayerContoll>().Rweapon, PBody.GetComponent<PlayerContoll>().Rhand.position, PBody.GetComponent<PlayerContoll>().Rhand.rotation, PBody.GetComponent<PlayerContoll>().Rhand);
                change = false;
            }
        }
        else if (this.gameObject.tag == "R")
        {
            PBody.GetComponent<PlayerContoll>().Rweapon = model;
            Instantiate(PBody.GetComponent<PlayerContoll>().Rweapon, PBody.GetComponent<PlayerContoll>().Rhand.position, PBody.GetComponent<PlayerContoll>().Rhand.rotation, PBody.GetComponent<PlayerContoll>().Rhand);
        }
        else if (this.gameObject.tag == "L")
        {
            PBody.GetComponent<PlayerContoll>().Lweapon = model;
            Instantiate(PBody.GetComponent<PlayerContoll>().Lweapon, PBody.GetComponent<PlayerContoll>().Lhand.position, PBody.GetComponent<PlayerContoll>().Lhand.rotation, PBody.GetComponent<PlayerContoll>().Lhand);
        }
        Vector3 oldScale = PBody.transform.Find("View").transform.Find("Ray").transform.localScale;
        Vector3 newScale = new Vector3(attackW, attackH, AttackDistance);
        PBody.transform.Find("View").transform.Find("Ray").transform.localScale=newScale;
        oldPos = PBody.transform.Find("View").transform.Find("Ray").transform.localPosition;

        float posz = oldPos.z - (oldScale.z - newScale.z) / 2;
        newPos = new Vector3(oldPos.x, oldPos.y, posz);

        PBody.transform.Find("View").transform.Find("Ray").transform.localPosition=newPos;
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PBody = other.gameObject;
            changeDistance();
            Destroy(this.gameObject);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        PBody = null;
    //    }
    //}
}
