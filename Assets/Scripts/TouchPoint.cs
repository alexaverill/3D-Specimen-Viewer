using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour {

	private int _id;
	public int Id{
		get{
			return _id;
		}
		set{
			_id = value;
		}
	}
}
