using UnityEngine;

public class PlayerCam_Mobile : PlayerCam
{
    protected Touch initTouch = new Touch();
    protected float rotX = 0f;
    protected float rotY = 0f;
    protected Vector3 origRot;
    protected float screenDivide = Screen.width / 2;// - (Screen.width * 0.1f);
    protected int dir = -1;
    
    private void Start(){
        origRot = playerBody.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    protected override void Update(){
        MobileControls(screenDivide);
    }

    /// <summary>
    /// A method that controls the camera with touch controls
    /// </summary>
    /// <param name="screenWidth"> A base width that divied the screen in half and allows for use of either side for controlling </param>
    void MobileControls(float screenWidth) {
        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.GetTouch(i);

                if (touch.position.x > screenWidth) {
                    if (touch.phase == TouchPhase.Began){
                        initTouch = touch;
                    }
                    else if (touch.phase == TouchPhase.Moved){

                        float deltaX = initTouch.position.x - touch.position.x;
                        float deltaY = initTouch.position.y - touch.position.y;

                        rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                        rotY += deltaX * Time.deltaTime * rotSpeed * dir;

                        rotX = Mathf.Clamp(rotX, -90f, 90f);
                        
                        playerBody.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                    }
                    else if (touch.phase == TouchPhase.Ended){
                        initTouch = new Touch();
                    }
                }
            }
        }
    }
}