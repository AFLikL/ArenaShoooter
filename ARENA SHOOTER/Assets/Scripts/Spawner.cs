using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public  List<GameObject> RandomEnemyPrefabs = new List<GameObject>();
    //public List<GameObject> NotRandomEnemyPrefabs = new List<GameObject>();
    List<GameObject> SpawnPoints = new List<GameObject>();
    public float spawntime;
    float old;
    int count=0;
    public int WaveCount;
    // Start is called before the first frame update
    void Start()
    {
        old = spawntime;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            SpawnPoints.Add(this.transform.GetChild(i).gameObject);
        } 
        Debug.Log(SpawnPoints.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
        randomSpawn(SpawnPoints,RandomEnemyPrefabs);
    }
    void randomSpawn(List<GameObject> sP,List<GameObject> tR) 
    {
        spawntime-=Time.deltaTime;

        if (WaveCount >= 0)
        {
            if (count > 0)
            {
                if (spawntime <= 0)
                {
                    Vector3 posSpawn = sP[Random.Range(0, sP.Count)].transform.position;
                    GameObject pref = tR[Random.Range(0, tR.Count)];
                    Instantiate(pref, posSpawn, Quaternion.identity);
                    count--;
                }
            }
            else { count = Random.Range(1, sP.Count); Debug.Log($"Кол-во врагов{count}"); spawntime = old;WaveCount--;}
        }
        
    }

}
