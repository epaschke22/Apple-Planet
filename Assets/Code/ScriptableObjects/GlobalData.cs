using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data")]
public class GlobalData : ScriptableObject
{
	public bool isPlayerAlive = true;
	public bool isWormAlive = true;
}
