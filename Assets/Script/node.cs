using UnityEngine;

public class node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null){
            Debug.Log("Can't build there!");
            return;
        }
        //build a turret
        GameObject turretToBulid = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBulid, transform.position + positionOffset, transform.rotation);

    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
