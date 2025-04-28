using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float Life;
    public int RestoreHp;
    public int RestoreMax;
    GameObject PBody;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Life -= Time.deltaTime;
        if (Life < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PBody = other.gameObject;
            if (PBody.GetComponent<PlayerContoll>().hp != PBody.GetComponent<PlayerContoll>().max)
            {

                PBody.GetComponent<PlayerContoll>().hp += Random.Range(RestoreHp,RestoreMax);
                if(PBody.GetComponent<PlayerContoll>().hp> PBody.GetComponent<PlayerContoll>().max) 
                {
                    PBody.GetComponent<PlayerContoll>().hp = PBody.GetComponent<PlayerContoll>().max;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
