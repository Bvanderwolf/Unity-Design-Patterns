using System;
using UnityEditor;
using UnityEngine;
using System.IO;

namespace BWolf.Patterns.Singleton.Editor
{
    [CustomPropertyDrawer(typeof(BootInfo))]
    public class BootInfoPropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Returns the total height of the property based on the amount of fields,
        /// whether the property is expanded in the editor and its boot mode value.
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!property.isExpanded)
                return (EditorGUIUtility.singleLineHeight);
            
            float height = (3 * EditorGUIUtility.singleLineHeight) + (1 * EditorGUIUtility.standardVerticalSpacing);
            if ((BootMode)property.FindPropertyRelative("_mode").enumValueIndex == BootMode.SCENE)
                height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            
            return (height);
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.BeginProperty(position, label, property);
            
            property.isExpanded = Foldout(position, property, label);
            
            position.y += EditorGUIUtility.singleLineHeight;
            position.height = EditorGUIUtility.singleLineHeight;
            
            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
                
                DrawPropertyRelative(position, property,"_prefab");

                MovePositionToNextLine(ref position);
                SerializedProperty mode = DrawPropertyRelative(position, property,"_mode");

                if ((BootMode)mode.enumValueIndex == BootMode.SCENE)
                {
                    MovePositionToNextLine(ref position);
                    DrawSceneNameProperty(position, property);
                }

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();
        }

        private static void DrawSceneNameProperty(Rect position, SerializedProperty property)
        {
            SerializedProperty sceneNameProperty = property.FindPropertyRelative("_sceneName");
            string[] scenes = GetNamesOfScenesInBuildSettings();
            string label = sceneNameProperty.displayName;
            
            if (scenes.Length == 0)
            {
                EditorGUI.LabelField(position, label, "<missing scenes in build settings>");
            }
            else
            {
                int selectedIndex = Array.FindIndex(scenes, s => s == sceneNameProperty.stringValue);
                if (selectedIndex == -1)
                    selectedIndex = 0;
            
                int newSelectedIndex = EditorGUI.Popup(position, label, selectedIndex, scenes);
                if (newSelectedIndex != selectedIndex)
                    sceneNameProperty.stringValue = scenes[newSelectedIndex];
            }
        }

        private static string[] GetNamesOfScenesInBuildSettings()
        {
            EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
            string[]  names = new string[scenes.Length];
            
            for (int i = 0; i < scenes.Length; i++)
                names[i] = Path.GetFileNameWithoutExtension(scenes[i].path);

            return (names);
        }

        private static SerializedProperty DrawPropertyRelative(Rect position, SerializedProperty property, string name)
        {
            SerializedProperty relativeProperty = property.FindPropertyRelative(name);
            EditorGUI.PropertyField(position, relativeProperty);
            return (relativeProperty);
        }

        private static void MovePositionToNextLine(ref Rect position)
        {
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            position.height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        }

        private static bool Foldout(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect rect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            return EditorGUI.Foldout(rect, property.isExpanded, label, true);
        }
    }
}
