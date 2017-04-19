using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public GameObject selected;

    [SerializeField] private InputField p_height;
    [SerializeField] private InputField p_width;
    [SerializeField] private InputField p_length;
    public Camera mainCamera;
	public Canvas can;
	public float default_fov = 30.0f;



	/// Awake is called when the script instance is being loaded.
	void Awake()
	{
		can.gameObject.SetActive(false);
	}


    // Use this for initialization
    void Start()
    {
        p_height.placeholder.GetComponent<Text>().text = "Height";
        p_width.placeholder.GetComponent<Text>().text = "Width";
        p_length.placeholder.GetComponent<Text>().text = "Length";

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Clicked");
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                selected = hitInfo.transform.gameObject;
                print(selected.name);
                PopulateUI(selected);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            print("Zooming in");
			mainCamera.fieldOfView--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            print("Zooming out");
			mainCamera.fieldOfView++;
        }

		if(Input.GetMouseButtonDown(2)){
			mainCamera.fieldOfView = default_fov;
		}

    }


    void LateUpdate(){
		if(selected && Input.GetMouseButtonDown(1)){
			float x = 0f;
			x+= Input.GetAxis("Mouse X") * 5.0f * 5f*.02f;
			Quaternion rotation = Quaternion.Euler(0, x, 0);
			Vector3 position = rotation * new Vector3(0, 0, 5) + selected.transform.position;
			// mainCamera.transform.position = position;
			mainCamera.transform.rotation = rotation;
		}
    }

    void PopulateUI(GameObject target)
    {
        print("Updating...");
        string height = target.transform.localScale.y.ToString();
        string width = target.transform.localScale.x.ToString();
        string length = target.transform.localScale.z.ToString();

        p_height.text = height;
        p_width.text = width;
        p_length.text = length;
		can.gameObject.SetActive(true);
    }
}

