using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelStats", menuName = "ScriptableObjects/Level", order = 1)]
public class LevelScriptableObject : ScriptableObject
{
    public int numberOfPieces;
    public int numberOfPowers;
    public float initialVelocity;

    public int finalScore;
    
}
