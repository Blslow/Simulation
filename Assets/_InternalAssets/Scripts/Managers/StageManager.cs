using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    private Transform entitiesParentObject;

    public Transform EntitiesParentObject { get => entitiesParentObject; }

    private void Awake()
    {
        if (EntitiesParentObject != null)
            ObjectPoolManager.EntitiesContainer = EntitiesParentObject;
    }
}
