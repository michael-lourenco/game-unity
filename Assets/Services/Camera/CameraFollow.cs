using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset = Vector3.up;
    private Vector3 newtrans;

    public float velocity = 5.0f;

    public float borderSize = 25.0f;
    private float screenX;
    private float screenY;

    public bool _isFreeCam;
    void Start()
    {
        _isFreeCam = false;
        /*offset.x = transform.position.x - player.transform.position.x;
        offset.z = transform.position.z - player.transform.position.z;
        offset.y = transform.position.y - player.transform.position.y;
        newtrans = transform.position;*/

        screenX = Screen.width;
        screenY = Screen.height;

    }

    
        /*void LateUpdate()
    {
        newtrans.x = player.transform.position.x + offset.x;
        newtrans.z = player.transform.position.z + offset.z;
        newtrans.y = player.transform.position.y + offset.y;
        transform.position = newtrans;

    }*/

    void Update()
    {
        /*newtrans.x = player.transform.position.x + offset.x;
        newtrans.z = player.transform.position.z + offset.z;
        newtrans.y = player.transform.position.y + offset.y;
        transform.position = newtrans;*/
        if(Input.GetKeyUp(KeyCode.Y)){
            ToogleFreeCam();
        }

        if(!_isFreeCam){
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, velocity*Time.deltaTime);
        } else {
            Vector3 pos = Vector3.zero;
            #region  Move x
            
            //Move para a esquerda
            if(Input.mousePosition.x < borderSize){
                pos.x = -1;
            }

            // Move para a direita

            if(Input.mousePosition.x > (screenX -borderSize)){
                pos.x = 1;
            }
            #endregion

            #region  Move y
            
            //Move para cima
            if(Input.mousePosition.y < 25){
                pos.y = -1;
            }

            // Move para baixo

            if(Input.mousePosition.y > (screenY - borderSize)){
                pos.y = 1;
            }
            #endregion

            if(pos == Vector3.zero){
                pos = GetKeyPosition();
            }

            transform.Translate(pos * velocity * Time.deltaTime);
        }
    }

    public void ToogleFreeCam(){
        _isFreeCam = !_isFreeCam;
    }

    private Vector3 GetKeyPosition() {
        return new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0
        );
    }
}