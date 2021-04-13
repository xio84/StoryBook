using System.Collections;
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

    public Sentence(string _text, bool _giveItem, bool _hasChoices, string _itemId, string[] _choices)
    {
        text = _text;
        giveItem = _giveItem;
        hasChoices = _hasChoices;
        itemId = _itemId;
        choices = _choices;
    }
}
