using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandData : MonoBehaviour
{
    public enum HandmodelType { left, right };

    public HandmodelType handtype;
    public Transform root;
    public Animator animator;
    public Transform[] fingerBones;
}
