using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
  public float movementSpeed = 3.0f;
  public float obstacleDistance = 5.0f;
  private bool _isAlive = true;
  
  // Start is called before the first frame update
  void Start()
  {
    _isAlive = true;    
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate (movementSpeed * Time.deltaTime, 0, -movementSpeed * Time.deltaTime);

    Ray ray = new Ray (transform.position, transform.forward);
    RaycastHit hit;
    
    if (Physics.SphereCast(ray, 0.75f, out hit)) {
      if (hit.distance < obstacleDistance) {
        float angle = Random.Range (-110, 110);
        transform.Rotate (0, angle, 0);
      }
    }
  }
}
