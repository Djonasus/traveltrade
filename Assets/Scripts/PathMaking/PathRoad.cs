using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Path", menuName = "Path")]
public class PathRoad : ScriptableObject
{
    public CityData Destination;
    public PathNode[] Nodes;
}
