using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor
{
    private SerializedProperty _name;
    private SerializedProperty _type;
    private SerializedProperty _description;
    private SerializedProperty _isEquipable;
    private SerializedProperty _isStackable;
    private SerializedProperty _maxQuantity;

    private SerializedProperty _baseDamage;
    private SerializedProperty _baseRange;
    private SerializedProperty _baseAccuracy;

    private SerializedProperty _baseDefense;

    private SerializedProperty _food;
    private SerializedProperty _water;

    private GUIStyle _sectionLabel;
    private GUIStyle _titleLabel;

    private void OnEnable()
    {
        _titleLabel = new GUIStyle();
        _titleLabel.fontSize = 18;
        _titleLabel.fontStyle = FontStyle.Bold;
        _titleLabel.alignment = TextAnchor.MiddleCenter;
        _titleLabel.normal.textColor = Color.white;

        _sectionLabel = new GUIStyle();
        _sectionLabel.fontSize = 14;
        _sectionLabel.fontStyle = FontStyle.Bold;
        _sectionLabel.alignment = TextAnchor.MiddleCenter;
        _sectionLabel.normal.textColor = Color.white;

        //general
        _name = serializedObject.FindProperty("_name");
        _type = serializedObject.FindProperty("_type");
        _description = serializedObject.FindProperty("_description");
        _isEquipable = serializedObject.FindProperty("_isEquipable");
        _isStackable = serializedObject.FindProperty("_isStackable");
        _maxQuantity = serializedObject.FindProperty("_maxQuantity");

        //weapon
        _baseDamage = serializedObject.FindProperty("_baseDamage");
        _baseRange = serializedObject.FindProperty("_baseRange");
        _baseAccuracy = serializedObject.FindProperty("_baseAccuracy");

        //armor
        _baseDefense = serializedObject.FindProperty("_baseDefense");

        //ressource
        _food = serializedObject.FindProperty("_food");
        _water = serializedObject.FindProperty("_water");
    }

    public override void OnInspectorGUI() 
    {
        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.LabelField(_name.stringValue.ToUpper(), _titleLabel);
        EditorGUILayout.Space(10);

        EditorGUILayout.LabelField("General Stats", _sectionLabel);
        EditorGUILayout.Space(5);

        EditorGUILayout.PropertyField(_name, new GUIContent("Name"));
        if (_name.stringValue == string.Empty)
        {
            EditorGUILayout.HelpBox("Caution: No name specified. Please name the entity!", MessageType.Warning);
        }

        EditorGUILayout.PropertyField(_type, new GUIContent("Item type"));
        EditorGUILayout.PropertyField(_description, new GUIContent("Description"));
        if(_type.intValue == 1 || _type.intValue == 2 || _type.intValue == 3)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(_isEquipable, new GUIContent("Can it be equipped?"));
        }

        if (_type.intValue == 3 || _type.intValue == 4)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(_isStackable, new GUIContent("Is it stackable?"));

            if(_isStackable.boolValue)
            {
                EditorGUILayout.PropertyField(_maxQuantity, new GUIContent("Maximum quantity"));
            }
        }

        if(_type.intValue == 1 && _isEquipable.boolValue)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Weapon stats", _sectionLabel);
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(_baseDamage, new GUIContent("Base Damage"));
            EditorGUILayout.PropertyField(_baseRange, new GUIContent("Base Range"));
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Base accuracy");
            _baseAccuracy.floatValue = EditorGUILayout.Slider(
                        _baseAccuracy.floatValue,
                        0f,
                        1f
                );
            EditorGUILayout.EndHorizontal();
        }

        if (_type.intValue == 2 && _isEquipable.boolValue)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Armor stats", _sectionLabel);
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(_baseDefense, new GUIContent("Base Defense"));
        }

        if (_type.intValue == 4)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Ressources amount", _sectionLabel);
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(_food, new GUIContent("Food"));
            EditorGUILayout.PropertyField(_water, new GUIContent("Water"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
