using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Callback = System.Action<string>;

public class MyViewObject : MonoBehaviour
{
	Callback callback;
	
	IntPtr myView;

#if UNITY_IPHONE
	[DllImport("__Internal")]
	private static extern IntPtr _MyViewPlugin_Init(string gameObject);
	[DllImport("__Internal")]
	private static extern int _MyViewPlugin_Destroy(IntPtr instance);
	[DllImport("__Internal")]
	private static extern void _MyViewPlugin_SetMargins(
		IntPtr instance, int left, int top, int right, int bottom);
	[DllImport("__Internal")]
	private static extern void _MyViewPlugin_SetVisibility(
		IntPtr instance, bool visibility);
	[DllImport("__Internal")]
	private static extern void _MyViewPlugin_LoadURL(
		IntPtr instance, string url);
#endif

	public void Init(Callback cb = null)
	{
		callback = cb;
#if UNITY_IPHONE
		myView = _MyViewPlugin_Init(name);
#endif
	}

	void OnDestroy()
	{
#if UNITY_IPHONE
		if (myView == IntPtr.Zero)
			return;
		_MyViewPlugin_Destroy(myView);
#endif
	}

	public void SetMargins(int left, int top, int right, int bottom)
	{
#if UNITY_IPHONE
		if (myView == IntPtr.Zero)
			return;
		_MyViewPlugin_SetMargins(myView, left, top, right, bottom);
#endif
	}

	public void SetVisibility(bool v)
	{
#if UNITY_IPHONE
		if (myView == IntPtr.Zero)
			return;
		_MyViewPlugin_SetVisibility(myView, v);
#endif
	}

	public void LoadURL(string url)
	{
#if UNITY_IPHONE
		if (myView == IntPtr.Zero)
			return;
		_MyViewPlugin_LoadURL(myView, url);
#endif
	}

	public void EvaluateJS(string js)
	{
#if UNITY_IPHONE
		if (myView == IntPtr.Zero)
			return;
#endif
	}

	public void CallFromJS(string message)
	{
		if (callback != null)
			callback(message);
	}
}
