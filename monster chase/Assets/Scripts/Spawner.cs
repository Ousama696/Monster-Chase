using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Spawner : MonoBehaviour

    
{
    [SerializeField]
    private GameObject[] MonstersRef;

    private GameObject SpawnedMonster;

    [SerializeField]
    private Transform leftpos, RightPos;

    private int RandomIndex;
    private int RandomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MonsterSpawn());
        
    }

    // Update is called once per frame
   
    IEnumerator MonsterSpawn()
    {
        while (0 == 0) { 
        yield return new WaitForSeconds(Random.Range(1, 8));
        RandomIndex = Random.Range(0, MonstersRef.Length);
        RandomSide = Random.Range(0, 2);
        SpawnedMonster = Instantiate(MonstersRef[RandomIndex]);
        
        if(RandomSide == 0)
        {
            SpawnedMonster.transform.position = leftpos.position;
            SpawnedMonster.GetComponent<Monsters>().speed = Random.Range(4, 10);
        }
        else
        {
            SpawnedMonster.transform.position = RightPos.position;
            SpawnedMonster.GetComponent<Monsters>().speed = -Random.Range(4, 10);
            SpawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        }
    }


}//class









