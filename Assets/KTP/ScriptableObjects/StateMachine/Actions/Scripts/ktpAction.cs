using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ktpAction : ScriptableObject
{
    public abstract void Act(ktpStateController controller);

}
