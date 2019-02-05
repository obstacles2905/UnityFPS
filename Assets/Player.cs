using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private int _health;
  
  // Start is called before the first frame update
  void Start()
  {
    _health = 5;   
  }

  // Update is called once per frame
  void Update()
  {
      
  }
  
  public void ReduceHealth(int damage)
  {
    _health -= damage;
    Debug.Log ("Your health is:" + _health);
  }
}
