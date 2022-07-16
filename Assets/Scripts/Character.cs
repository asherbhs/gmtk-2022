using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
public struct CharacterInfo
{
    public string name;
    public string spritePath;
    public string dialoguePath;
}

[Serializable]
public struct AllCharacterInfo
{
    public CharacterInfo[] allCharacterInfo;
}

public class CharacterData
{
    public string name;
    public Sprite sprite;
    public DialogueTree dialogueTree;

    public CharacterData(CharacterInfo info)
    {
        name = info.name;
        sprite = Resources.Load<Sprite>(info.spritePath);
        dialogueTree = JsonUtility.FromJson<DialogueTree>
        (
            Resources.Load(info.dialoguePath).ToString()
        );
    }
}

public class Character : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CharacterData[] allCharacterData;
    private int characterIndex;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // load list of characters from json
        AllCharacterInfo allInfo = JsonUtility.FromJson<AllCharacterInfo>
        (
            Resources.Load("AllCharacterData").ToString()
        );
        allCharacterData = new CharacterData[allInfo.allCharacterInfo.Length];
        for (int i = 0; i < allInfo.allCharacterInfo.Length; i++)
        {
            allCharacterData[i] = new CharacterData(allInfo.allCharacterInfo[i]);
        }
    }

    void Start()
    {
        characterIndex = -1;
        NextCharacter();
    }

    void NextCharacter()
    {
        characterIndex++;
        spriteRenderer.sprite = allCharacterData[characterIndex].sprite;
    }
}
