using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private int multiplierFactor = 1;
    private List<Clone> cloneList = new List<Clone>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Clone clone))
        {
            if (!IsCloneCloned(clone))
            {
                AddCloneToList(clone);
                SpawnManager.Instance.SpawnProjectile(other.gameObject.transform, other.gameObject, multiplierFactor, this);
            }
        }
    }

    public void AddCloneToList(Clone clone)
    {
        if (!cloneList.Contains(clone))
        {
            cloneList.Add(clone);
        }
    }

    private bool IsCloneCloned(Clone clone)
    {
        return cloneList.Contains(clone);
    }
}
