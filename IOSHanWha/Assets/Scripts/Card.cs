using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : BaseInstance
{
    public enum UltType { NULL, FROST, BURN, POISON, SHOCK };

    public UltType ultType = UltType.NULL;
}
