using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropSpeedConfig", menuName = "ConfigMenu/DropSpeedConfig", order = 1)]
public class MinMaxDropSpeedConfig : ScriptableObject
{
    public float minDropSpeedConfig;
    public float maxDropSpeedConfig;
}
