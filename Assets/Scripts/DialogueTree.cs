using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
public class ThreeDice
{
    public string animal;
    // frog, wolf, rabbit, bird, cat, fish
    public string weather;
    // lightning, sun, wind, snow, rain, cloud
    public string rune;
    // peorth, aangor, ehwan, isa, akhon, fo-un
}

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
    public ThreeDice threeDice;
    public DialogueOption[] dialogueOptions;
}

[Serializable]
public class DialogueForest
{
    public DialogueTree[] forest;
}