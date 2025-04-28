using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerContoll : MonoBehaviour
{
    // Start is called before the first frame updateww
    public float speed;
    Vector3 moveDir;
    GameObject Enemy=null;
    //public float gravity;
    public float jumpForce;
    bool onFlor=true;
    //CharacterController body;
    float dist;
    public int hp;
    public int max;
    public float PattackTime;
    float attackTime;
    public int AttackDamage;
    public GameObject Rweapon;
    public GameObject Lweapon;
    public Transform Lhand, Rhand;
    Animator animator;
    Rigidbody rb;
    int rand;
    bool run=false;

    private void Awake()
    {
        Lhand = this.gameObject.transform.Find("body").Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:LeftShoulder").Find("mixamorig:LeftArm").Find("mixamorig:LeftForeArm").Find("mixamorig:LeftHand").Find("mixamorig:LWeapon");
        Rhand = this.gameObject.transform.Find("body").Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:RightShoulder").Find("mixamorig:RightArm").Find("mixamorig:RightForeArm").Find("mixamorig:RightHand").Find("mixamorig:RWeapon");
    }
    void Start()
    {

        //body = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        attackTime = PattackTime;
        max = hp;
        animator = this.transform.Find("body").GetComponent<Animator>();
       /* Lhand= this.gameObject.transform.Find("body").Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:LeftShoulder").Find("mixamorig:LeftArm").Find("mixamorig:LeftForeArm").Find("mixamorig:LeftHand").Find("mixamorig:LWeapon");
        // Rhand= this.gameObject.transform.Find("body").Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:RightShoulder").Find("mixamorig:RightArm").Find("mixamorig:RightForeArm").Find("mixamorig:RightHand").Find("mixamorig:RWeapon");
        //  Instantiate(Lweapon, this.gameObject.transform.Find("body").Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:LeftShoulder").Find("mixamorig:LeftArm").Find("mixamorig:LeftForeArm").Find("mixamorig:LeftHand").Find("mixamorig:LWeapon"));
        //  Collider = GetComponent<Collider>();
       */
    }
    // Update is called once per frame
    void Update()
    {
        move();
        fight();
       // rotation();
    }
    void move()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (run == false)
            {
                animator.SetTrigger("runr");
                animator.SetBool("run", true);
                run = true;
            }
        }
        else {
            animator.SetBool("run", false);
            run = false;
        }
      //  \else { animator.SetBool("run", false); run = false; }

        moveDir = transform.forward * v + transform.right * h;
        if (onFlor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(rb.transform.up * jumpForce);
            }
        }
        rb.velocity =new Vector3(moveDir.x,rb.velocity.y,moveDir.z);
       /* Physics.gravity = Vector3.Lerp(Physics.gravity, new Vector3(0, -120f, 0), Time.deltaTime);// #постепенно увеличивает гравитацию.

      

        //moveDir.y -= gravity * Time.deltaTime;

        // body.Move(moveDir * speed * Time.deltaTime);


        // Debug.Log(body.isGrounded);
       */

    }
    void fight() 
    {
        PattackTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rand = Random.Range(1, 3);
            if (rand == 1)
            {
                animator.SetTrigger("Pr");
            }
            else
            {
                animator.SetTrigger("Pl");
            }
            if (Enemy!=null) 
            {
                
                //if (Enemy.transform.GetComponent<EnemyScript>().hp <= 0)
                //{
                //    StartCoroutine(DelEn());
                //}
                //else
                if(Enemy.transform.GetComponent<EnemyScript>().hp > 0 && PattackTime<=0 )
                {
                    MinusHpEn();
                   

                    Debug.Log(Enemy.GetComponent<EnemyScript>().hp);
                    PattackTime = attackTime;
                }
            }
        }
        
        void MinusHpEn()
        {
            Enemy.GetComponent<EnemyScript>().hp -= AttackDamage;
        }
        IEnumerator DelEn()
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(Enemy);
            Debug.Log("Death");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HitBox")
        {
            Enemy = other.gameObject;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HitBox")
        {
            Enemy = null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "floor") 
        {
            onFlor = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onFlor = false;
        }
        
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        dist = Vector3.Distance(this.gameObject.transform.position, other.transform.position);
        Debug.Log(dist);
        if (dist <= 3)
        {
            // Destroy(other.gameObject);
        }
    }*/

    /*
    void rotation() 
    { 
        
        float mouseX= Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY= Input.GetAxis("Mouse Y")* Time.deltaTime;
        xRot -= mouseY;
        xRot= Mathf.Clamp(xRot, -90f, 90f);
        body.transform.rotation=Quaternion.Euler(mouseX,0f,0f);
    }*/
}