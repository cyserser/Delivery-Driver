using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

   bool hasPackage;
   [SerializeField] float destroyDelay = 0.5f;
   [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
   [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

   SpriteRenderer spriteRenderer;

   private void Start() {
       spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void OnCollisionEnter2D(Collision2D other) {

       Debug.Log("Collision detected!!!");
       
   }

   private void OnTriggerEnter2D(Collider2D other) {

       //Debug.Log("Trigger activated !!!");

       if(other.tag == "Package" && !hasPackage){
           Debug.Log("Package picked up!");
           Destroy(other.gameObject, destroyDelay);
           hasPackage = true;
           spriteRenderer.color = hasPackageColor;
       }
       
       if(other.tag == "Customer" && hasPackage){
           Debug.Log("Package delivered!");
           hasPackage = false;
           spriteRenderer.color = noPackageColor;
       }
          
       
   }
}
