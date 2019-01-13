using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	private Camera _camera;
  private int LEFT_CLICK_BUTTON = 0;
  
	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera>();	
    
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetMouseButtonDown(LEFT_CLICK_BUTTON)) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
      Ray ray = _camera.ScreenPointToRay(point); //cоздание луча
      RaycastHit hit;
      
      if (Physics.Raycast(ray, out hit)) {
        StartCoroutine (SphereIndicator (hit.point));
      }
		}

	}
  
  private IEnumerator SphereIndicator(Vector3 pos) {
    GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
    sphere.transform.position = pos;
    
    yield return new WaitForSeconds (1);
    
    Destroy (sphere);
  }
}
