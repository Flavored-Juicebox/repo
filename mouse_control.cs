using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_control : MonoBehaviour
{
    [SerializeField] private float mouse_Sensitivity, camera_Smoothing, raycast_Max_Distance, gravitate_Speed, max_Grab_Distance, save_Drag;
    [SerializeField] private GameObject character_Obj, weapon_Obj;
    [SerializeField] private Transform desired_Pos;
    [SerializeField] private bool item_slot;
    [SerializeField] private weapon wpn;
    private GameObject grabbed_Obj;
    private Vector2 mouse_Look, smooth_V;
    RaycastHit item_Ray;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        #region camera
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md *= mouse_Sensitivity * camera_Smoothing;

        smooth_V.x = Mathf.Lerp(smooth_V.x, md.x, 1f / camera_Smoothing);
        smooth_V.y = Mathf.Lerp(smooth_V.y, md.y, 1f / camera_Smoothing);

        mouse_Look += smooth_V;
        mouse_Look.y = Mathf.Clamp(mouse_Look.y, -90f, 90f);

        transform.localRotation = Quaternion.Euler(-mouse_Look.y, 0f, 0f);
        character_Obj.transform.rotation = Quaternion.Euler(0f, mouse_Look.x, 0f);
        #endregion

        #region grab

        //Input.GetMouseButtonDown(0) ? : 

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out item_Ray, raycast_Max_Distance))
            {
                item_Ray.transform.GetComponent<Rigidbody>();
                grabbed_Obj = item_Ray.transform.gameObject;

            }
        }
        else if (Input.GetMouseButtonUp(0) && grabbed_Obj != null)
        {
            grabbed_Obj = null;
        } 


        if (grabbed_Obj)
        {
            grabbed_Obj.GetComponent<Rigidbody>().velocity = gravitate_Speed / grabbed_Obj.GetComponent<Rigidbody>().mass * (desired_Pos.transform.position - grabbed_Obj.transform.position);

            if (tools.Distance(character_Obj.transform.position, grabbed_Obj.transform.position) > max_Grab_Distance)
            {
                grabbed_Obj = null;
            }
        }
        #endregion

        #region item slot
            switch (item_slot)
            {
                
            }
        #endregion
    }
}
