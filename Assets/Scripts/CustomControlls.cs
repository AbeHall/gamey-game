using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomControls", menuName = "Simulacrum/CustomControls", order = 52)]
public class CustomControls : ScriptableObject
{
    [SerializeField] public KeyCode upKey;
    [SerializeField] public KeyCode downKey;
    [SerializeField] public KeyCode leftKey;
    [SerializeField] public KeyCode rightKey;

    [SerializeField] public KeyCode jumpKey;

    [SerializeField] public KeyCode lightKey;
}
