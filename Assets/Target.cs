using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ReactToHit()
    {
      StartCoroutine (Die ());
    }
    
    private IEnumerator Die()
    {
      this.gameObject.transform.Rotate (75, 0, 0);
  
      yield return new WaitForSeconds (0.5f); // action happens 1.5seconds after the trigger called
      Destroy (this.gameObject);
    }
}
