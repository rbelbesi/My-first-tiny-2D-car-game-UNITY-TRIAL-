using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool HasThePackage; //defualt is false 
    [SerializeField] float DestroyDelay=0.5f;
    [SerializeField] Color32 HasThePackageColour= new Color32 (1,1,1,1);
    [SerializeField] Color32 HasNoPackageColour=new Color32 (1,1,1,1);

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        
    }
  /* void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OUTCH!!!");
     
    }*/
     void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !HasThePackage)
        {
            HasThePackage=true;
            spriteRenderer.color= HasThePackageColour;
            Destroy(other.gameObject, DestroyDelay);
            Debug.Log("Package Picked Up!");
        }//if 

        if (other.tag == "Customer" && HasThePackage)
        {
            Debug.Log("Delivered Package!");
            HasThePackage=false;
            spriteRenderer.color=HasNoPackageColour;
        }//if

        
    }
}
