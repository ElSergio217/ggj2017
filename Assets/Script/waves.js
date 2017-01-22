#pragma strict


var moveSpeed:float;
var point:Transform;


function Start () {

}

function Update () {

	point.Rotate(Vector3.up * moveSpeed * Time.deltaTime);


}