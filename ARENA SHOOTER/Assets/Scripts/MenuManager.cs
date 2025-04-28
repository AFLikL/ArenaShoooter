using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public static GameObject[] canvass;
    Camera notActive;
    GameObject can;
    CollectCanvs h;
    public AudioSource MainMenuMusic;
    public static GameObject[] voluMe;
    Slider slid;
    // Start is called before the first frame update
    private void Start()
    {
        voluMe = GameObject.FindGameObjectsWithTag("slide");
        Debug.Log(voluMe.Length);
        slid = voluMe[0].GetComponent<Slider>();
        MainMenuMusic.volume = slid.value;

        canvass = GameObject.FindGameObjectsWithTag("canv"); finCan("levelChoice").SetActive(false);
        finCan("levelChoice").GetComponent<Canvas>().worldCamera.gameObject.SetActive(false);
        Debug.Log("ебаный");
    }
    public void VolumeChanged()
    {
        MainMenuMusic.volume = slid.value;
        for(int i = 0; i < voluMe.Length; i++)
        {
            voluMe[i].GetComponent<Slider>().value = slid.value;
        }
    }
    GameObject finCan(string name)
    {
        Console.WriteLine("старт ебаный");
        for (int i = 0; i < canvass.Length; i++)
        {
            if (canvass[i].name == name)
            {
                return canvass[i];
            }
        }
        return null;
    }
    public void Play()
    {
        slid = voluMe[1].GetComponent<Slider>();
        finCan("levelChoice").SetActive(true);
         finCan("levelChoice").GetComponent<Canvas>().worldCamera.gameObject.SetActive(true);
        finCan("startScreen").SetActive(false);
        finCan("startScreen").GetComponent<Canvas>().worldCamera.gameObject.SetActive(false);
        

        //GameObject.Find("levelChoice").gameObject.GetComponent<Canvas>().worldCamera = ch;
        //SceneManager.LoadScene(1);
    }
    public void back()
    {
        slid = voluMe[0].GetComponent<Slider>();
        finCan("startScreen").SetActive(true);
        finCan("startScreen").GetComponent<Canvas>().worldCamera.gameObject.SetActive(true);

        finCan("levelChoice").SetActive(false);
        finCan("levelChoice").GetComponent<Canvas>().worldCamera.gameObject.SetActive(false);
        //SceneManager.LoadScene(1);
    }

    public void Arena1()
    {
        SceneManager.LoadScene(3);
    }
    public void Arena2()
    {
        SceneManager.LoadScene(2);
    }
    public void Arena3()
    {
        SceneManager.LoadScene(1);
    }

    public void Over()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
