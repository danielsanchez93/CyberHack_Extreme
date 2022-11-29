using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPooler : MonoBehaviour
{
    [SerializeField] GameObject[] chars;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] int amountToPool;

    private List<GameObject> pooledChars = new List<GameObject>();

    private void Start()
    {
        GameObject temp;
        for (int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(GetRandomChar(), transform);
            temp.SetActive(false);
            pooledChars.Add(temp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledChars.Count; i++)
        {
            if (!pooledChars[i].activeInHierarchy)
            {

                return pooledChars[i];
            }
        }
        GameObject temp;
        temp = Instantiate(GetRandomChar(), transform);
        temp.SetActive(false);
        pooledChars.Add(temp);
        return temp;
    }


    [ContextMenu("Spawn Char")]
    public void SpawnNewChar()
    {
        GameObject go = Instantiate(GetRandomChar(), GetRandomSpawnPoint(), Quaternion.identity, transform);
        go.GetComponent<CharMovement>()?.InitializeCharacter();
        go.GetComponent<HackVulnerable>()?.ResetVulnerabilities();
        pooledChars.Add(go);

    }

    private GameObject GetRandomChar()
    {
        int ran = Random.Range(0,chars.Length);
        return chars[ran];
    }

    private Vector3 GetRandomSpawnPoint()
    {
        int ran = Random.Range(0,spawnPoints.Length);
        float posY = Random.Range(-0.59f,-3.8f);
        Vector3 newPos = new Vector3(spawnPoints[ran].position.x,posY,0);
        return newPos;
    }

    public void ResetChar(GameObject character)
    {
        character.SetActive(false);
    }
}
