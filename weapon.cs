using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] private shoot_scriptable shoot_;
    [SerializeField] private bullet_scriptable bullet_;
    [SerializeField] private Transform bullet_origin, desired_position;
    [SerializeField] public Rigidbody body;
    [SerializeField] ParticleSystem muzzle_flash;
    [SerializeField] private bool is_automatic, has_ammo;
    private float shot_time;

    RaycastHit hit;
    void Start()
    {
        body.drag = shoot_.recoil_drag;
        body.angularDrag = shoot_.recoil_angular;
    }

    void Update()
    {
        #region follow
        var a = tools.Distance(transform.position, desired_position.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, Camera.main.transform.rotation, Time.deltaTime * 5);
        transform.position = Vector3.MoveTowards(transform.position, desired_position.position, Time.deltaTime * a * 3);
        #endregion

        #region shoot
        //if (Input.GetMouseButtonDown(2)) is_holstered = !is_holstered;
        //if (is_holstered) return;
        if (!is_automatic ? Input.GetMouseButtonDown(1) : Input.GetMouseButton(1))
        {
            float dif = Time.realtimeSinceStartup - shot_time;
            if (dif < shoot_.fire_rate)
            {
                return;
            }

            #region shot
            muzzle_flash.Play();
            for (int i = 0; i < shoot_.fire_amount; i++)
            {
                body.AddRelativeForce(Vector3.back * 100, ForceMode.Force);
                body.AddRelativeTorque(Vector3.left * 100, ForceMode.Force);

                Vector3 random_offset = new Vector3(Random.Range(0, shoot_.spread_bounds.x), Random.Range(0, shoot_.spread_bounds.y), 0f);
                GameObject bullet_prefab = Instantiate(bullet_.bullet_Object, bullet_origin.position, Quaternion.identity);
                bullet_prefab.GetComponent<Rigidbody>().AddForce((bullet_origin.forward + random_offset) * bullet_.force, ForceMode.VelocityChange);
                Destroy(bullet_prefab, shoot_.maximum_range);
            }
            #endregion

            shot_time = Time.realtimeSinceStartup;
        }
        #endregion


    }
}
