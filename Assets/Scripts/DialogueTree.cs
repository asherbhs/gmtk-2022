using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
public class DialogueOption
{
    public string playerResponse;
    public int karma;
    public DialogueTree subTree;
}

[Serializable]
public class DialogueTree
{
    public string[] characterDialogue;
    public string outcome;
    public DialogueOption[] dialogueOptions;
}
