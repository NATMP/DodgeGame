using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockManager : MonoBehaviour
{
    [SerializeField] GameObject prefabRock;
    List<GameObject> rockPool = new List<GameObject>();
    [SerializeField] float rockSpawnTime;
    [SerializeField] Transform[] spawnPosition;
    private int spawnIndex;
    public static int countRock;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRock());
    }
    IEnumerator SpawnRock()
    {
        while (true)
        {
            yield return new WaitForSeconds(rockSpawnTime);
            spawnIndex = Random.Range(0, spawnPosition.Length);
            Vector2 spawnPos = spawnPosition[spawnIndex].position;
            bool rockActive = false;
            foreach (GameObject rock in rockPool)
            {
                if (rock.activeSelf)
                    continue;
                if (countRock >= 4)
                    continue;
                rock.transform.position = spawnPos;
                countRock++;
                rock.SetActive(true);
                rockActive = true;
                break;
            }
            if (rockActive)
                continue;
            if (countRock >= 4)
                continue;
            rockPool.Add(Instantiate(prefabRock, spawnPos, Quaternion.identity));
            countRock++;
        }
    }
}
