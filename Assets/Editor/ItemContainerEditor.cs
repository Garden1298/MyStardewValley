using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemContainer))]
public class ItemContainerEditor : Editor
{
   public override void OnInspectorGUI()
   {
        ItemContainer container = target as ItemContainer;

        //컨테이너 클리어 하는 버튼
        if(GUILayout.Button("Clear container"))
        {
            for(int i = 0; i<container.slots.Count; i++)
            {
                container.slots[i].Clear();
            }
        }
        DrawDefaultInspector();
    }
}
