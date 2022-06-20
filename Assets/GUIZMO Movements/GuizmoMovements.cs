using UnityEngine;
[RequireComponent(typeof(Camera))]
public class GuizmoMovements : MonoBehaviour
{
    #region Values
    [Header("---------------------------------------")]
    [Header("GUIZMO Movements by Oris Romero")]
    // General Values    
    public GameObject objectToTransform;
    public Collider colliderWall;
    Camera camara;
    float objectZ;    
    // Rotation Values
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    public float mFuerza;
        public float mFuerzaFinal;


    // Raycast Values
    GameObject[] rayCollider = new GameObject[2];
    Ray ray;
    RaycastHit hit;
    // Mouse Dragging Point Difference Values
    bool dragging;
    Vector2 earlyPos;
    Vector2 fixedPos;
    Vector2 unitsMoved;
    #endregion
    
    void Start() {
        objectZ = objectToTransform.transform.position.z;
        camara = GetComponent<Camera>();
        camara.orthographic = true;        
                 }
    
    void Update() {        
        ray = camara.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.cyan);
        #region -- If RaycastHit is Succefull --
        if (Physics.Raycast(ray, out hit) == true && hit.transform.gameObject == colliderWall.gameObject)
        {            
            earlyPos = new Vector2(hit.point.x, hit.point.y);
           
            #region ROTATION
            if (Input.GetMouseButton(0))
            {
                mPosDelta = Input.mousePosition - mPrevPos;

                mFuerza = mPosDelta.x + mPosDelta.y + mPosDelta.z;
  
                Debug.Log(mFuerza);
            }

            /*
        if (Vector3.Dot(objectToTransform.transform.up, Vector3.up) >= 0)
        {
             objectToTransform.transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, camara.transform.right), Space.World);
        }
        else
        {
            objectToTransform.transform.Rotate(-transform.up, Vector3.Dot(mPosDelta, camara.transform.right), Space.World);
        }
        objectToTransform.transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, camara.transform.up), Space.World);*/
        }
                #endregion
                mPrevPos = Input.mousePosition;

            /*
            #region POSITION
            if (Input.GetMouseButton(2))
            {
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                objectToTransform.transform.position = new Vector3(hit.point.x, hit.point.y, objectZ);
            }
            #endregion
            #region SCALE
            if (Input.GetMouseButton(1))
            {
                objectToTransform.transform.localScale = new Vector3(objectToTransform.transform.localScale.x + unitsMoved.x / 2,
                                                          objectToTransform.transform.localScale.y + unitsMoved.x / 2,
                                                          objectToTransform.transform.localScale.z + unitsMoved.x / 2);
                objectToTransform.transform.localScale = new Vector3(objectToTransform.transform.localScale.x + unitsMoved.y / 2,
                                                          objectToTransform.transform.localScale.y + unitsMoved.y / 2,
                                                          objectToTransform.transform.localScale.z + unitsMoved.y / 2);

            }
            #endregion
            */
        }
        #endregion
    
    /*
    void FixedUpdate()
    {
        ray = camara.ScreenPointToRay(Input.mousePosition);
        #region Units Moved after Mouse Dragging
        if (Physics.Raycast(ray, out hit) == true)
        {            
            fixedPos = new Vector2(hit.point.x, hit.point.y);
            unitsMoved = new Vector2(fixedPos.x - earlyPos.x, fixedPos.y - earlyPos.y);
            if (unitsMoved.x != 0 || unitsMoved.y != 0) { dragging = true; }
            else { dragging = false; }
        }
        #endregion
    }*/
}
