using UnityEngine;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: RaycastShoot
/// </summary>
public class RaycastShoot : MonoBehaviour {
    #region Fields

    public float rayDistance;
    public string tagName = "Enemy";

    #endregion

    void Start() {}

    void Update() {
        ShootRay();
    }

    void ShootRay() {
        //Determine if we are pressing left mouse button
        if (Input.GetMouseButtonDown(0)) {
            //Setup raycast to run from Main Camera to mouse position
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Used to get information back from a raycast
            RaycastHit hit;

            //Determine if our raycast hits anything
            if (Physics.Raycast(ray, out hit, rayDistance)) {
                Debug.Log(hit.transform.name);
                //Determine if our raycast hit an object with our tag
                if (hit.transform.tag == tagName ) {
                    //pull in enemy script
                    //do damage
                    Enemy enemyHit = hit.transform.GetComponent<Enemy>();
                    //enemyHit.health -= Weapon damage
                } else { //not enemy
                    
                }
            } else {
                //miss
            }
        }
    }

    #region Fields

    #endregion
}