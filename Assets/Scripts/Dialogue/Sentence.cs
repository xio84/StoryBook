﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence
{
    [TextArea(3, 10)]
    public string text;

    public bool giveItem;

    public bool hasChoices;

    public string itemId;

    public string[] choices;
}
