using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode]
public class RandomGenWindow : EditorWindow 
{
	public Object ObjectToSpawn;
	public Object TargetCube;
	public int EncryptionCount = 1;
	
	[MenuItem ("Tools/Random Encryption Placer")]
	public static void ShowWindow() 
	{
		EditorWindow.GetWindow(typeof(RandomGenWindow));
	}
	
	void OnGUI() 
	{
		GUILayout.Label("Base Settings", EditorStyles.boldLabel);
		ObjectToSpawn = EditorGUILayout.ObjectField("Object to Clone:", ObjectToSpawn, typeof(GameObject), true);
		TargetCube = EditorGUILayout.ObjectField("Target Cube:", TargetCube, typeof(GameObject), true);
		EncryptionCount = EditorGUILayout.IntSlider("Object Count:", EncryptionCount, 1, 100);
		if (GUILayout.Button("Spawn Objects")) 
		{
			for (int i = 0; i < EncryptionCount; i++)
			{
				SpawnObject(ObjectToSpawn, TargetCube);
			}
		}
	}
	
	public void SpawnObject(Object spawnableThing, Object targetLocation)
	{
		Vector3 rndPosWithin = targetLocation.transform.TransformPoint(Random.Range(-1f, 1f) * .5f, Random.Range(-1f, 1f) * .5f, Random.Range(-1f, 1f) * .5f);
		Instantiate(spawnableThing, rndPosWithin, targetLocation.transform.rotation);
	}
}



