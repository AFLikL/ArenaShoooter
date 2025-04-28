using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveWeapon : MonoBehaviour
{
    public static GameObject Rweapon,Lweapon;
    public static Transform Left,right;
    void Start()
    {
        Left = this.gameObject.transform.Find("Body").Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:LeftShoulder").Find("mixamorig:LeftArm").Find("mixamorig:LeftForeArm").Find("mixamorig:LeftHand").Find("mixamorig:LWeapon");
        right = this.gameObject.transform.Find("Body").Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:RightShoulder").Find("mixamorig:RightArm").Find("mixamorig:RightForeArm").Find("mixamorig:RightHand").Find("mixamorig:RWeapon");
        //Lweapon.transform.SetParent(this.gameObject.transform.Find("mixamorig:LeftShoulder").Find("mixamorig:LeftArm").Find("mixamorig:LeftForeArm").Find("mixamorig:LeftHand").Find("mixamorig:LWeapon"));
        //Rweapon.transform.SetParent(this.gameObject.transform.Find("mixamorig:RightShoulder").Find("mixamorig:RightArm").Find("mixamorig:RightForeArm").Find("mixamorig:RightHand").Find("mixamorig:RWeapon"));
        if (this.gameObject.transform.Find("mixamorig:LeftShoulder").Find("mixamorig:LeftArm").Find("mixamorig:LeftForeArm").Find("mixamorig:LeftHand").Find("mixamorig:LWeapon")) {
            Instantiate(Lweapon, this.gameObject.transform.Find("mixamorig:LeftShoulder").Find("mixamorig:LeftArm").Find("mixamorig:LeftForeArm").Find("mixamorig:LeftHand").Find("mixamorig:LWeapon"));
            Debug.Log("лево");
        }
       if (this.gameObject.transform.Find("mixamorig:RightShoulder").Find("mixamorig:RightArm").Find("mixamorig:RightForeArm").Find("mixamorig:RightHand").Find("mixamorig:RWeapon"))
        {
            Debug.Log("право");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
