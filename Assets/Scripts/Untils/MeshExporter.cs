using UnityEngine;
using UnityEditor;
using System.Collections;

public static class MeshExporter
{
	[MenuItem("Assets/MeshExporter")]

	static void SaveAsset()
	{
		Transform obj = Selection.activeObject as Transform;
		MeshFilter[] m1 = obj.GetComponents<MeshFilter>();
        foreach (MeshFilter item in m1)
        {
			AssetDatabase.CreateAsset(item.mesh, "Assets/" + item.name + ".asset");
		}
		
	}

}