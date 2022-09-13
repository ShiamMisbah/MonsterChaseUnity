using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject [] monsterReference;

    private GameObject spawnedMonster;
    [SerializeField]
    private Transform leftPosn, rightPosn;

    private int randomIndex, randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
        Debug.Log("Monster Created4");
    }

    IEnumerator SpawnMonsters(){
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            Debug.Log("Monster Created1");

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]); //Instantiate func creates a copy of the object from reference index.
            Debug.Log("Monster Created2");
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPosn.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(2, 7);
            }
            else
            {
                spawnedMonster.transform.position = rightPosn.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(2, 7);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            Debug.Log("Monster Created3");
        }
    }    
}
