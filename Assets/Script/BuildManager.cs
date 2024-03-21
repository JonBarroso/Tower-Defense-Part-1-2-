using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BuildManager instance;

    void Awake()
    {
        if (instance!= null)
        {
            Debug.LogError("More Than on Manager in scene!");
            return;
        }
        instance = this;
    }
    public GameObject standardTurretPrefab;

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild;


    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
}
