using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    // This Script is for educational purposes only
    // NOT USED
    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private GameObject ghost;

    [SerializeField]
    private Transform rightPos;

    // [SerializeField]
    // private Transform leftPos;

    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    IEnumerator SpawnMonsters()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 20));

            /* randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(ghost);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(4, 10);
            } else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            } */

            spawnedMonster = Instantiate(ghost);
            spawnedMonster.transform.position = rightPos.position;
            spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(4, 10);
            spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
