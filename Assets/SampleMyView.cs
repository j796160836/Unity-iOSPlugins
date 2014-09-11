using UnityEngine;
using System.Collections;

public class SampleMyView : MonoBehaviour
{
		MyViewObject myViewObject;
	
		void Start ()
		{
				myViewObject =
			(new GameObject ("MyViewObject")).AddComponent<MyViewObject> ();
				myViewObject.Init ((msg) => {
						Debug.Log (string.Format ("CallFromJS[{0}]", msg));
				});
		
				myViewObject.SetMargins (5, 5, 5, 40);
				myViewObject.SetVisibility (true);
		}
}