using UnityEditor;

using UnityEditorInternal;

//Tells the Editor class that this will be the Editor for the WaveManager
[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    SerializedProperty stats;

    ReorderableList list;

    private void OnEnable()
    {
        stats = serializedObject.FindProperty("stats");

        list = new ReorderableList(serializedObject, stats, true, true, true, true);

        list.drawElementCallback = DrawListItems;
        list.drawHeaderCallback = DrawHeader;

    }

    void DrawListItems(UnityEngine.Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index); //The element in the list


        EditorGUI.PropertyField(
            new UnityEngine.Rect(rect.x, rect.y, 150, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("enumStat"),
            UnityEngine.GUIContent.none
        );

        EditorGUI.LabelField(new UnityEngine.Rect(rect.x + 170, rect.y, 120, EditorGUIUtility.singleLineHeight), "value");

        EditorGUI.PropertyField(
            new UnityEngine.Rect(rect.x + 210, rect.y, 100, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("value"),
            UnityEngine.GUIContent.none
        );
    }

    void DrawHeader(UnityEngine.Rect rect)
    {
        string name = "stats";
        EditorGUI.LabelField(rect, name);
    }

    //This is the function that makes the custom editor work
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();
    }
}