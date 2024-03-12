using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EntityData))]
public class EntityDataEditor : Editor
{
    private SerializedProperty _name;
    private SerializedProperty _entityType;
    private SerializedProperty _chanceToDropItem;
    private SerializedProperty _rangeOfAwareness;
    private SerializedProperty _canEnterCombat;

    private SerializedProperty _strengh;
    private SerializedProperty _agility;
    private SerializedProperty _constitution;
    private SerializedProperty _sanity;
    private SerializedProperty _maxHP;

    private SerializedProperty _battleCry;
    private SerializedProperty _abilities;

    private void OnEnable()
    {
        _name = serializedObject.FindProperty("_name");
        _entityType = serializedObject.FindProperty("_monsterType");
        _chanceToDropItem = serializedObject.FindProperty("_chanceToDropItem");
        _rangeOfAwareness = serializedObject.FindProperty("_rangeOfAwareness");
        _canEnterCombat = serializedObject.FindProperty("_canEnterCombat");

        _strengh = serializedObject.FindProperty("_strengh");
        _agility = serializedObject.FindProperty("_agility");
        _constitution = serializedObject.FindProperty("_constitution");
        _sanity = serializedObject.FindProperty("_sanity");
        _maxHP = serializedObject.FindProperty("_maxHP");

        _battleCry = serializedObject.FindProperty("_battleCry");
        _abilities = serializedObject.FindProperty("_abilities");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.LabelField(_name.stringValue.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        float difficulty = (_strengh.intValue * 1.5f) + (_agility.intValue * 0.5f) + (_constitution.intValue * 1f);
        ProgressBar(difficulty / 100, "Difficulty");
        EditorGUILayout.Space(5);

        //add something to draw before
        //base.OnInspectorGUI();       //base form of the inspector drawn
        //add something to draw after

        //custom GUI here
        EditorGUILayout.LabelField("General Stats", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(_name, new GUIContent("Name"));
        if (_name.stringValue == string.Empty)
        {
            EditorGUILayout.HelpBox("Caution: No name specified. Please name the entity!", MessageType.Warning);
        }

        EditorGUILayout.PropertyField(_entityType, new GUIContent("Entity type"));
        //EditorGUILayout.LabelField("Item drop chance");
        //_chanceToDropItem.floatValue = EditorGUILayout.Slider(
        //            _chanceToDropItem.floatValue,
        //            0,
        //            100
        //    );
        //EditorGUILayout.PropertyField(_rangeOfAwareness, new GUIContent("Range of awareness"));
        EditorGUILayout.PropertyField(_canEnterCombat, new GUIContent("Can enter combat?"));
        EditorGUILayout.Space(10);

        if(_canEnterCombat.boolValue)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Combat Stats", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 85;

            EditorGUILayout.PropertyField(_strengh, new GUIContent("Strengh"));
            if(_strengh.intValue < 0)
            {
                EditorGUILayout.HelpBox("Monsters shouldn't have negative Strengh.", MessageType.Warning);
            }

            EditorGUILayout.PropertyField(_agility, new GUIContent("Agility"));
            if (_agility.intValue < 0)
            {
                EditorGUILayout.HelpBox("Monsters shouldn't have negative Agility.", MessageType.Warning);
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(_constitution, new GUIContent("Constitution"));
            if (_constitution.intValue < 0)
            {
                EditorGUILayout.HelpBox("Monsters shouldn't have negative Constitution.", MessageType.Warning);
            }

            EditorGUILayout.PropertyField(_sanity, new GUIContent("Sanity"));


            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Random Stats"))
            {
                RandomStats();
            }

            RecalculateHP();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Max HP", EditorStyles.boldLabel);
            EditorGUILayout.LabelField(_maxHP.intValue + "");
            EditorGUILayout.EndHorizontal();

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Dialogue", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_battleCry, new GUIContent("Battle Cry"));

        EditorGUILayout.Space(5);
        EditorGUILayout.PropertyField(_abilities, new GUIContent("Abilities"));



        serializedObject.ApplyModifiedProperties();
    }

    private void RecalculateHP()
    {
        _maxHP.intValue = _constitution.intValue * 3;
    }

    private void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 25, "Textfield");
        EditorGUI.ProgressBar(rect, value, label);
    }

    private void RandomStats()
    {
        _strengh.intValue = Random.Range(1, 26);
        _agility.intValue = Random.Range(1, 26);
        _constitution.intValue = Random.Range(1, 26);
        _sanity.intValue = Random.Range(-10, 26);
    }
}
