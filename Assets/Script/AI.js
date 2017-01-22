#pragma strict

var player:GameObject;
var speed:float;


 function Update()
 {
     GetClosestObject("Player");
	transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime* speed);
	transform.LookAt(player.transform.position);
 }
 
 function GetClosestObject(tag:String) : GameObject
 {
     var objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
     var closestObject : GameObject;
     for (var obj : GameObject in objectsWithTag)
     {
         if(!closestObject)
         {
            closestObject = obj;
         }
         //compares distances
         if(Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closestObject.transform.position))
         {
            closestObject = obj;
         }
     }
     player = closestObject.gameObject;
 }

 function OnTriggerEnter(other:Collider){
     if(other.tag=="Bullet"){
         if(GameObject.FindGameObjectsWithTag("eye").length < GameObject.FindGameObjectsWithTag("Player").length * 10){
             player.GetComponent.<newAI>().spawn();
        }
         GetComponent.<Rigidbody>().useGravity=true;
 		GetComponent.<SphereCollider>().isTrigger=false;
 		die();
 		this.enabled=false;
 	}
 }

 function die(){
 	yield WaitForSeconds(5);
 	Destroy(gameObject);
 }