using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonsterData))]
public class MonsterDataEditor : Editor
{
    private SerializedProperty _name;
    private SerializedProperty _monsterType;
    private SerializedProperty _chanceToDropItem;
    private SerializedProperty _rangeOfAwareness;
    private SerializedProperty _canEnterCombat;

    private SerializedProperty _damage;
    private SerializedProperty _health;
    private SerializedProperty _speed;

    private SerializedProperty _battleCry;
    private SerializedProperty _abilities;

    private void OnEnable()
    {
        _name = serializedObject.FindProperty("_name");
        _monsterType = serializedObject.FindProperty("_monsterType");
        _chanceToDropItem = serializedObject.FindProperty("_chanceToDropItem");
        _rangeOfAwareness = serializedObject.FindProperty("_rangeOfAwareness");
        _canEnterCombat = serializedObject.FindProperty("_canEnterCombat");

        _damage = serializedObject.FindProperty("_damage");
        _health = serializedObject.FindProperty("_health");
        _speed = serializedObject.FindProperty("_speed");

        _battleCry = serializedObject.FindProperty("_battleCry");
        _abilities = serializedObject.FindProperty("_abilities");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.LabelField(_name.stringValue.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        float difficulty = _damage.intValue + _health.intValue + _speed.intValue;
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
            EditorGUILayout.HelpBox("Caution: No name specified. Please name the monster!", MessageType.Warning);
        }

        EditorGUILayout.PropertyField(_monsterType, new GUIContent("Monster type"));
        EditorGUILayout.LabelField("Item drop chance");
        _chanceToDropItem.floatValue = EditorGUILayout.Slider(
                    _chanceToDropItem.floatValue,
                    0,
                    100
            );
        EditorGUILayout.PropertyField(_rangeOfAwareness, new GUIContent("Range of awareness"));
        EditorGUILayout.PropertyField(_canEnterCombat, new GUIContent("Can enter combat?"));
        EditorGUILayout.Space(10);

        if(_canEnterCombat.boolValue)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Combat Stats", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 70;

            EditorGUILayout.PropertyField(_health, new GUIContent("Health"));
            if(_health.intValue < 0)
            {
                EditorGUILayout.HelpBox("Monsters shouldn't have negative health.", MessageType.Warning);
            }
            EditorGUILayout.PropertyField(_speed, new GUIContent("Speed"));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(_damage, new GUIContent("Damage"));

            if(GUILayout.Button("Random Stats"))
            {
                RandomStats();
            }

            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel--;

        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Dialogue", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_battleCry, new GUIContent("Battle Cry"));
        EditorGUILayout.PropertyField(_abilities, new GUIContent("Abilities"));



        serializedObject.ApplyModifiedProperties();
    }

    private void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 25, "Textfield");
        EditorGUI.ProgressBar(rect, value, label);
    }

    private void RandomStats()
    {
        _damage.intValue = Random.Range(1, 26);
        _health.intValue = Random.Range(1, 26);
        _speed.intValue = Random.Range(1, 26);
    }
}
