using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EntityData))]
public class EntityDataEditor : Editor
{
    private SerializedProperty _name;
    private SerializedProperty _entityType;
    private SerializedProperty _canDropItems;
    private SerializedProperty _chanceToDropItem;
    private SerializedProperty _rangeOfAwareness;
    private SerializedProperty _canEnterCombat;

    private SerializedProperty _strengh;
    private SerializedProperty _agility;
    private SerializedProperty _constitution;
    private SerializedProperty _sanity;
    private SerializedProperty _affinity;
    private SerializedProperty _movement;
    private SerializedProperty _maxHPFlatBonus;
    private SerializedProperty _maxHPScaleBonus;

    private SerializedProperty _fireDamageBonus;
    private SerializedProperty _meleeDamageBonus;
    private SerializedProperty _rangedDamageBonus;

    private SerializedProperty _rangedAccuracyBonus;
    private SerializedProperty _meleeAccuracyBonus;

    private SerializedProperty _battleCry;
    private SerializedProperty _abilities;
    private SerializedProperty _traits;
    private SerializedProperty _weaponList;

    private GUIStyle _sectionLabel;
    private GUIStyle _subSectionLabel;
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

        _subSectionLabel = new GUIStyle();
        _subSectionLabel.fontSize = 12;
        _subSectionLabel.fontStyle = FontStyle.Bold;
        _subSectionLabel.normal.textColor = Color.white;

        _name = serializedObject.FindProperty("_name");
        _entityType = serializedObject.FindProperty("_entityType");
        _rangeOfAwareness = serializedObject.FindProperty("_rangeOfAwareness");
        _canEnterCombat = serializedObject.FindProperty("_canEnterCombat");

        _canDropItems = serializedObject.FindProperty("_canDropItems");
        _chanceToDropItem = serializedObject.FindProperty("_chanceToDropItem");

        _strengh = serializedObject.FindProperty("_strengh");
        _agility = serializedObject.FindProperty("_agility");
        _constitution = serializedObject.FindProperty("_constitution");
        _sanity = serializedObject.FindProperty("_sanity");
        _affinity = serializedObject.FindProperty("_affinity");
        _movement = serializedObject.FindProperty("_movement");
        _maxHPFlatBonus = serializedObject.FindProperty("_maxHPFlatBonus");
        _maxHPScaleBonus = serializedObject.FindProperty("_maxHPScaleBonus");

        _fireDamageBonus = serializedObject.FindProperty("_fireDamageBonus");
        _meleeDamageBonus = serializedObject.FindProperty("_meleeDamageBonus");
        _rangedDamageBonus = serializedObject.FindProperty("_rangedDamageBonus");

        _rangedAccuracyBonus = serializedObject.FindProperty("_rangedAccuracyBonus");
        _meleeAccuracyBonus = serializedObject.FindProperty("_meleeAccuracyBonus");

        _battleCry = serializedObject.FindProperty("_battleCry");
        _abilities = serializedObject.FindProperty("_abilities");
        _traits = serializedObject.FindProperty("_traits");
        _weaponList = serializedObject.FindProperty("_weaponList");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.LabelField(_name.stringValue.ToUpper(), _titleLabel);
        EditorGUILayout.Space(10);

        float difficulty = (_strengh.intValue * 1.5f) + (_agility.intValue * 0.5f) + (_constitution.intValue * 1f);
        ProgressBar(difficulty / 100, "Difficulty");
        EditorGUILayout.Space(5);

        //add something to draw before
        //base.OnInspectorGUI();       //base form of the inspector drawn
        //add something to draw after

        //custom GUI here
        EditorGUILayout.LabelField("General Stats", _sectionLabel);
        EditorGUILayout.Space(10);

        EditorGUILayout.PropertyField(_name, new GUIContent("Name"));
        if (_name.stringValue == string.Empty)
        {
            EditorGUILayout.HelpBox("Caution: No name specified. Please name the entity!", MessageType.Warning);
        }

        EditorGUILayout.PropertyField(_entityType, new GUIContent("Entity type"));
        EditorGUILayout.Space(5);

        EditorGUILayout.PropertyField(_canDropItems, new GUIContent("Can drop items?"));
        if(_canDropItems.boolValue)
        {
            EditorGUILayout.LabelField("Chance to drop item");
            _chanceToDropItem.floatValue = EditorGUILayout.Slider(
                        _chanceToDropItem.floatValue,
                        0,
                        100
                );
        }
        EditorGUILayout.Space(5);
        //EditorGUILayout.PropertyField(_rangeOfAwareness, new GUIContent("Range of awareness"));
        EditorGUILayout.PropertyField(_canEnterCombat, new GUIContent("Can enter combat?"));
        EditorGUILayout.Space(10);

        if(_canEnterCombat.boolValue)
        {
            EditorGUILayout.LabelField("Combat Stats", _sectionLabel);
            EditorGUILayout.Space(10);
            EditorGUI.indentLevel++;

            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 90;
            EditorGUILayout.PropertyField(_strengh, new GUIContent("Strengh"));
            EditorGUILayout.PropertyField(_agility, new GUIContent("Agility"));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(_constitution, new GUIContent("Constitution"));
            EditorGUILayout.PropertyField(_sanity, new GUIContent("Sanity"));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.PropertyField(_movement, new GUIContent("Movement"));

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Affinity");
            _affinity.intValue = Mathf.FloorToInt(EditorGUILayout.Slider(
                        _affinity.intValue *1f,
                        -100f,
                        100f
                ));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("Hit points", _subSectionLabel);
            EditorGUIUtility.labelWidth = 120;
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(_maxHPFlatBonus, new GUIContent("Flat Modifier"));
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Scaling modifier");
            _maxHPScaleBonus.floatValue = EditorGUILayout.Slider(
                        _maxHPScaleBonus.floatValue,
                        0.1f,
                        5f
                );
            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("Damage modifiers", _subSectionLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Fire damage");
            _fireDamageBonus.floatValue = EditorGUILayout.Slider(
                        _fireDamageBonus.floatValue,
                        0.1f,
                        3f
                );
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Melee damage");
            _meleeDamageBonus.floatValue = EditorGUILayout.Slider(
                        _meleeDamageBonus.floatValue,
                        0.1f,
                        3f
                );
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Ranged damage");
            _rangedDamageBonus.floatValue = EditorGUILayout.Slider(
                        _rangedDamageBonus.floatValue,
                        0.1f,
                        3f
                );
            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("Accuracy modifiers", _subSectionLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Ranged Accuracy Bonus");
            _rangedAccuracyBonus.floatValue = EditorGUILayout.Slider(
                        _rangedAccuracyBonus.floatValue,
                        0.1f,
                        3f
                );
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Melee Accuracy Bonus");
            _meleeAccuracyBonus.floatValue = EditorGUILayout.Slider(
                        _meleeAccuracyBonus.floatValue,
                        0.1f,
                        3f
                );
            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel--;

            if (_strengh.intValue < 0)
            {
                EditorGUILayout.HelpBox("Entities shouldn't have negative Strengh.", MessageType.Warning);
            }

            if (_agility.intValue < 0)
            {
                EditorGUILayout.HelpBox("Entities shouldn't have negative Agility.", MessageType.Warning);
            }

            if (_constitution.intValue < 0)
            {
                EditorGUILayout.HelpBox("Entities shouldn't have negative Constitution.", MessageType.Warning);
            }

            if (_maxHPFlatBonus.intValue < 0)
            {
                EditorGUILayout.HelpBox("Make sure the negative flat HP bonus doesn't bring the entity below 0.", MessageType.Warning);
            }

            if (_movement.intValue < 0)
            {
                EditorGUILayout.HelpBox("Entities shouldn't have negative Movement", MessageType.Warning);
            }

            EditorGUILayout.Space(5);
            if (GUILayout.Button("Random Stats"))
            {
                RandomStats();
            }

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Dialogues", _sectionLabel);
        EditorGUILayout.PropertyField(_battleCry, new GUIContent("Battle Cry"));

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Passives and Actives", _sectionLabel);
        EditorGUILayout.Space(5);
        EditorGUILayout.PropertyField(_abilities, new GUIContent("Abilities"));

        EditorGUILayout.Space(5);
        EditorGUILayout.PropertyField(_traits, new GUIContent("Traits"));

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Inventory", _sectionLabel);
        EditorGUILayout.Space(5);
        EditorGUILayout.PropertyField(_weaponList, new GUIContent("Weapons"));

        serializedObject.ApplyModifiedProperties();
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
