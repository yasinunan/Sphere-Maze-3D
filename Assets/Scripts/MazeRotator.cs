using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MazeRotator : MonoBehaviour
{
	public GameObject _mainCamera;
	public GameObject _rotationCamera;
	public float waitingTime = 10f;
	public Slider mySlider;

	public float xLimit = 45f;
	public float yLimit = 45f;
	public float zLimit = 45f;

	public bool xRot;
	public bool yRot;
	public bool zRot;

	// Start is called before the first frame update
	void Start()
	{
		mySlider.onValueChanged.AddListener(delegate {
			StartCoroutine(SwitchCameras());
			RotateMe();
			
			//DesetParent();
		});
	}

	public void RotateMe()
	{
		if (xRot)
			transform.localEulerAngles = new Vector3(mySlider.value * xLimit, transform.localEulerAngles.y, transform.localEulerAngles.z);
		if (yRot)
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, mySlider.value * yLimit, transform.localEulerAngles.z);
		if (zRot)
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, mySlider.value * zLimit);
	}

	public void SetParent()
    {
		_mainCamera.transform.parent = gameObject.transform;
	}

	public void DesetParent()
	{
		_mainCamera.transform.parent = null;
	}

	public IEnumerator SwitchCameras()
    {
		Debug.Log("kamera deðiþtirildi");
		//Vector3 _position = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y, _mainCamera.transform.position.z);
		//_rotationCamera.transform.position = _position;
		//Vector3 _rotation = new Vector3(_mainCamera.transform.rotation.x, _mainCamera.transform.rotation.y, _mainCamera.transform.rotation.z);

		//_rotationCamera.transform.localEulerAngles = new Vector3(_mainCamera.transform.localEulerAngles.x, _mainCamera.transform.localEulerAngles.y, _mainCamera.transform.localEulerAngles.z);
		//_rotationCamera.transform.parent = null;
		_rotationCamera.SetActive(true);
		_mainCamera.SetActive(false);

		yield return new WaitForSeconds(waitingTime);
		//_rotationCamera.transform.parent = _mainCamera.transform;
		_rotationCamera.SetActive(false);
		_mainCamera.SetActive(true);

		Debug.Log("kamera geri deðiþtirildi");
	}




	/* public float speed = 1f;
	 public Transform objectToRotate;

	public void RotateObject()
	 {
		 float sliderValue = GetComponent<Slider>().value;

		 objectToRotate.transform.rotation = Quaternion.Euler(0, sliderValue * 360*Time.deltaTime, 0);
	 }*/
}
