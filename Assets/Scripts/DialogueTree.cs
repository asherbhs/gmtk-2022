using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
public struct DialogueOption
{
    public string playerResponse;
    public int karma;
    public DialogueTree subTree;
}

[Serializable]
public struct DialogueTree
{
    public string[] characterDialogue;
    public DialogueOption[] dialogueOptions;
}
