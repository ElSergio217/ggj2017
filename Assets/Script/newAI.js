#pragma strict
var ai:GameObject;
function Start () {
	
}

public function spawn () {
     Instantiate(ai, new Vector3(Random.Range(-35, 35), Random.Range(0, 20), Random.Range(-35, 35)), transform.rotation);
     Instantiate(ai, new Vector3(Random.Range(-35, 35), Random.Range(0, 20), Random.Range(-35, 35)), transform.rotation);
}
