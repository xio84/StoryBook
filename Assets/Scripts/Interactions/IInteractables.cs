﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractables : IThinkable
{
    bool Interact(string key);
}
