using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SpriteLibraryChange : MonoBehaviour
{
    [SerializeField] SpriteLibraryAsset[] spriteLibraries;

    SpriteLibrary spriteLibrary;

    private void Awake()
    {
        spriteLibrary = GetComponent<SpriteLibrary>();        
    }

    //private void OnEnable()
    //{
    //    SetRandomSpriteLibrary();
    //}

    public void SetRandomSpriteLibrary()
    {
        spriteLibrary.spriteLibraryAsset = GetRandomSpriteLibrary();
    }

    private SpriteLibraryAsset GetRandomSpriteLibrary()
    {
        int ran = Random.Range(0,spriteLibraries.Length);
        return spriteLibraries[ran];
    }
}
