using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /// <summary>
    /// Time between spawned objects
    /// TODO: Variable - random
    /// </summary>
    public Vector2 timeToSpawn;
    /// <summary>
    /// Initial quantity of character to spawn
    /// </summary>
    public int initSpawn;

    public float posYSensibility;

    [SerializeField] Transform[] spawnPoints;

    private Transform lastPos;

    CharPooler characterPooler;
    CharMovement charMovement;


    private void Start()
    {
        characterPooler = FindObjectOfType<CharPooler>();
        StartCoroutine(nameof(SpawnCharacterOnTime));
    }

    IEnumerator SpawnCharacterOnTime()
    {
        SpawnCharacter();
        float ran = Random.Range(timeToSpawn.x,timeToSpawn.y);
        yield return new WaitForSeconds(ran);
        StartCoroutine(nameof(SpawnCharacterOnTime));
    }
    
    private void SpawnCharacter() 
    {
        GameObject go = characterPooler.GetPooledObject();
        InitializeCharacter(go);
        go.GetComponent<HackVulnerable>()?.ResetVulnerabilities();
        go.GetComponent<SpriteLibraryChange>().SetRandomSpriteLibrary();
        go.SetActive(true);
    }

    public void InitializeCharacter(GameObject character)
    {
        character.transform.position = GetRandomSpawnPoint();
        character.GetComponent<SpriteRenderer>().sortingOrder = Mathf.Abs((int)character.transform.position.y);
        charMovement = character.GetComponent<CharMovement>();
        if (character.transform.position.x < 0)
        {
            character.transform.localScale = Vector3.one;
            charMovement.speed = Mathf.Abs(charMovement.speed);
        }
        else
        {
            character.transform.localScale = new Vector3(-1, 1, 1);
            charMovement.speed = -charMovement.speed;
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        int ran = Random.Range(0, spawnPoints.Length);
        while (spawnPoints[ran] == lastPos)
        {
            ran = Random.Range(0, spawnPoints.Length);            
        }
        lastPos = spawnPoints[ran];
        Vector3 newPos = spawnPoints[ran].position;
        return newPos;
    }

}
