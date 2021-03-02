using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour {
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

	void Update () {
        if(Input.GetMouseButtonDown(1)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(1)){
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
            Camera.main.transform.position = new Vector3(
                Mathf.Clamp(Camera.main.transform.position.x, -10, 10),
                Mathf.Clamp(Camera.main.transform.position.y, -8, 8),
                Camera.main.transform.position.z);
        }
        zoom(Input.GetAxis("Mouse ScrollWheel")*2);
	}

    void zoom(float increment){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}