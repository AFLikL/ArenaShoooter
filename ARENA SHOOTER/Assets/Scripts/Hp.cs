using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    //public delegate void Some(int arg);
    //public event Some a;
    PlayerContoll player;
    Slider Bar;
    public event Action minusHp;

    float max;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerContoll>();
        Bar= this.GetComponent<Slider>();
        max=player.hp;
        Bar.maxValue = max;
    }
    private void Update()
    {
       ShowHp();
    }
    // Update is called once per frame
    void ShowHp()
    {

        Bar.value =(float) player.hp;
       // Debug.Log(Bar.fillAmount);

    }
}
