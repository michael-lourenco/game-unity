using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ktp/Decision")]
public abstract class ktpDecision : ScriptableObject
{
    public abstract bool Decide(ktpStateController controller);
}
