using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    [SerializeField]
    private GameObject winText;

	// Use this for initialization
	void Start () {
       HideWinText();
	}

    public void HideWinText() {
        winText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Albania.locked && Austria.locked && Belarus.locked && Belguim.locked && 
            BosniaHerzegovina.locked && Bulgaria.locked && Croatia.locked && 
            Czechia.locked && Denmark.locked && Estonia.locked && Finland.locked && 
            France.locked && Germany.locked && Greece.locked && Hungary.locked && 
            Iceland.locked && Ireland.locked && Italy.locked && Kosovo.locked && 
            Latvia.locked && Lithuania.locked && Luxembourg.locked && 
            Macedonia.locked && Moldova.locked && Montenegro.locked && 
            Netherlands.locked && Norway.locked && Poland.locked && Portugal.locked && 
            Romania.locked && Serbia.locked && Slovakia.locked && Slovenia.locked && 
            Spain.locked && Sweden.locked && Switzerland.locked && Turkey.locked && 
            Ukraine.locked){
            winText.SetActive(true);
        }
    }
}
