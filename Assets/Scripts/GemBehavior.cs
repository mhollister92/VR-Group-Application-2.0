using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehavior : MonoBehaviour
{
public GemClass gem;
public Renderer gemMaterial;

// Start is called before the first frame update
void Start()
{
    gemMaterial = gameObject.GetComponent<Renderer>();
}
// Update is called once per frame
void Update()
{

    //if (redParticles.hit)
    //{
    //    if (!IsActive(1))
    //    {
    //        gemMaterial.material.color = new Color(gem.rValue / 255f, gemMaterial.material.color.g, gemMaterial.material.color.b, gemMaterial.material.color.a);
    //    }
    //}
}

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Red"))
    {
        if (!IsActive(1))
        {
            gemMaterial.material.color = new Color(gem.rValue / 255f, gemMaterial.material.color.g, gemMaterial.material.color.b, gemMaterial.material.color.a);
        }
    }
    else if (other.CompareTag("Green"))
    {
        if (!IsActive(2))
        {
            gemMaterial.material.color = new Color(gemMaterial.material.color.r, gem.gValue / 255f, gemMaterial.material.color.b, gemMaterial.material.color.a);
        }
    }
    else if (other.CompareTag("Blue"))
    {
        if (!IsActive(3))
        {
            gemMaterial.material.color = new Color(gemMaterial.material.color.r, gemMaterial.material.color.g, gem.bValue / 255f, gemMaterial.material.color.a);
        }
    }
    if (IsAllActive())
    {
        gemMaterial.material.color = new Color(gem.rValue / 255f, gem.gValue / 255f, gem.bValue / 255f, gemMaterial.material.color.a);
    }
}
bool IsActive(int color)
{
    if (color == 1)
    {
        return gem.rActive;
    }
    else if (color == 2)
    {
        return gem.gActive;
    }
    else if (color == 3)
    {
        return gem.gActive;
    }
    else
        return false;
}
bool IsAllActive()
{
    if (gem.rActive && gem.gActive && gem.bActive)
    {
        return true;
    }
    else
        return false;
}
}