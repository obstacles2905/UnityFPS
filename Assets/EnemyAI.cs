using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
  public float movementSpeed = 3.0f;
  public float obstacleDistance = 5.0f;
  private bool _isAlive = true;
  [SerializeField] private GameObject fireballPrefab;
  private GameObject _fireball;
   
  // Start is called before the first frame update
  void Start()
  {
    _isAlive = true;    
  }

  // Update is called once per frame
  bool Update()
  {
    if (!_isAlive) {
      return false; 
    }
    transform.Translate (movementSpeed * Time.deltaTime, 0, -movementSpeed * Time.deltaTime);

    Ray ray = new Ray (transform.position, transform.forward);
    RaycastHit hit;

    if (Physics.SphereCast (ray, 0.75f, out hit)) {
      GameObject hitObject = hit.transform.gameObject;
      
      if(hitObject.GetComponent<Player>()) {
        if (!_fireball) {
          this.createFireball();
        }
      }

      else if (hit.distance < obstacleDistance) {
        float angle = UnityEngine.Random.Range (-510, 510);
        transform.Rotate (0, angle, 0);
      }
    }

    return true;
   }

  
  public void SetAlive(bool alive)
  {
    _isAlive = alive;
  }
  
  public void createFireball()
  {
    _fireball = Instantiate (fireballPrefab) as GameObject;

    _fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
    _fireball.transform.rotation = transform.rotation;
  }
}
