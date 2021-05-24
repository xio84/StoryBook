using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjects : IThinkable
{
    // Interact with environmental object
    void Interact(GameObject player);
}
