using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class JSON{
	public static string filePath = Application.dataPath + "/StreamingAssets/touchPointData.json"; 

	public static List<TouchData> readTouchPoints(){
		List<TouchData> returnList = new List<TouchData>();
		if(System.IO.File.Exists(filePath)){
			returnList = JsonConvert.DeserializeObject<List<TouchData>>(System.IO.File.ReadAllText(filePath));
		}
		return returnList;
	}

	public static bool writeTouchPoints(List<TouchData> pointsToWrite){
		System.IO.File.WriteAllText(filePath,JsonConvert.SerializeObject(pointsToWrite));
		return true;
	}

	public static bool writeSpecimen(SpecimenClass specimen){
		System.IO.File.WriteAllText(filePath,JsonConvert.SerializeObject(specimen));
		return true;
	}
}
