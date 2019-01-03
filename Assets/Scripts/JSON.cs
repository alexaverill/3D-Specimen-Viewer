using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class JSON{
	public static string filePath = Application.dataPath + "/StreamingAssets/specimens.json"; 

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

	public static bool writeSpecimen(List<SpecimenClass> specimenList){
		//todo add in file and directory creation
		System.IO.File.WriteAllText(filePath,JsonConvert.SerializeObject(specimenList));
		return true;
	}
	public static List<SpecimenClass> readSpecimens(){
		List<SpecimenClass> list = new List<SpecimenClass>();
		if(System.IO.File.Exists(filePath)){
			list = JsonConvert.DeserializeObject<List<SpecimenClass>>(System.IO.File.ReadAllText(filePath));
		}
		return list;
	}
}
