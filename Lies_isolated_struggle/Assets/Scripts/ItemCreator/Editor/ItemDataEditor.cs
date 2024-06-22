using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor
{
    private SerializedProperty _name;
    private SerializedProperty _typeOfItem;
    private SerializedProperty _typeOfWeapon;
    private SerializedProperty _description;
    private SerializedProperty _isEquipable;
    private SerializedProperty _isStackable;
    private SerializedProperty _maxQuantity;

    private SerializedProperty _baseDamage;
    private SerializedProperty _baseRange;
    private SerializedProperty _baseAccuracy;

    public SerializedProperty _baseMagazineSize;
    public SerializedProperty _basePelletsPerShot;
    public SerializedProperty _baseBulletsPerShot;
    public SerializedProperty _rateOfFire;
    public SerializedProperty _firingCooldown;
    public SerializedProperty _spread;
    public SerializedProperty _reloadSpeed;
    public SerializedProperty _weaponShootingType;

    private SerializedProperty _baseDefense;

    private SerializedProperty _food;
    private SerializedProperty _water;

    private SerializedProperty _shootingAudio;
    private SerializedProperty _relaodingAudio;

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
        _typeOfItem = serializedObject.FindProperty("_typeOfItem");
        _typeOfWeapon = serializedObject.FindProperty("_typeOfWeapon");
        _description = serializedObject.FindProperty("_description");
        _isEquipable = serializedObject.FindProperty("_isEquipable");
        _isStackable = serializedObject.FindProperty("_isStackable");
        _maxQuantity = serializedObject.FindProperty("_maxQuantity");

        //weapon
        _baseDamage = serializedObject.FindProperty("_baseDamage");
        _baseRange = serializedObject.FindProperty("_baseRange");
        _baseAccuracy = serializedObject.FindProperty("_baseAccuracy");

        //Gun
        _baseMagazineSize = serializedObject.FindProperty("_baseMagazineSize");
        _basePelletsPerShot = serializedObject.FindProperty("_basePelletsPerShot");
        _baseBulletsPerShot = serializedObject.FindProperty("_baseBulletsPerShot");
        _rateOfFire = serializedObject.FindProperty("_rateOfFire");
        _firingCooldown = serializedObject.FindProperty("_firingCooldown");
        _spread = serializedObject.FindProperty("_spread");
        _reloadSpeed = serializedObject.FindProperty("_reloadSpeed");
        _weaponShootingType = serializedObject.FindProperty("_weaponShootingType");

        //armor
        _baseDefense = serializedObject.FindProperty("_baseDefense");

        //ressource
        _food = serializedObject.FindProperty("_food");
        _water = serializedObject.FindProperty("_water");

        //Audio
        _shootingAudio = serializedObject.FindProperty("_shootingAudio");
        _relaodingAudio = serializedObject.FindProperty("_relaodingAudio");
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

        EditorGUILayout.PropertyField(_typeOfItem, new GUIContent("Item type"));
        EditorGUILayout.PropertyField(_description, new GUIContent("Description"));
        if(_typeOfItem.intValue == 1 || _typeOfItem.intValue == 2 || _typeOfItem.intValue == 3)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(_isEquipable, new GUIContent("Can it be equipped?"));
        }

        if (_typeOfItem.intValue == 3 || _typeOfItem.intValue == 4)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(_isStackable, new GUIContent("Is it stackable?"));

            if(_isStackable.boolValue)
            {
                EditorGUILayout.PropertyField(_maxQuantity, new GUIContent("Maximum quantity"));
            }
        }

        if(_typeOfItem.intValue == 1 && _isEquipable.boolValue)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.PropertyField(_typeOfWeapon, new GUIContent("Weapon type"));

            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Weapon stats", _sectionLabel);
            EditorGUILayout.Space(5);

            switch (_typeOfWeapon.enumValueIndex)
            {
                case (int)WeaponType.Gun:
                {
                    EditorGUILayout.PropertyField(_baseDamage, new GUIContent("Base damage"));
                    EditorGUILayout.PropertyField(_baseRange, new GUIContent("Base range"));

                    EditorGUILayout.PropertyField(_baseMagazineSize, new GUIContent("Base magazine size"));
                    EditorGUILayout.PropertyField(_basePelletsPerShot, new GUIContent("Base pellets per shot"));
                    EditorGUILayout.PropertyField(_baseBulletsPerShot, new GUIContent("Base bullets per shot"));
                    EditorGUILayout.PropertyField(_rateOfFire, new GUIContent("Rate of fire"));
                    EditorGUILayout.PropertyField(_firingCooldown, new GUIContent("Cooldown between shots"));
                    EditorGUILayout.PropertyField(_spread, new GUIContent("Amount of spread"));
                    EditorGUILayout.PropertyField(_reloadSpeed, new GUIContent("Reload speed"));
                    EditorGUILayout.PropertyField(_weaponShootingType, new GUIContent("Type of shooting"));

                    EditorGUILayout.PropertyField(_shootingAudio, new GUIContent("Sound while shooting"));
                    EditorGUILayout.PropertyField(_relaodingAudio, new GUIContent("Sound for reloading"));
                    break;
                }
                case (int)WeaponType.Sword:
                {
                    EditorGUILayout.PropertyField(_baseDamage, new GUIContent("Base damage"));
                    EditorGUILayout.PropertyField(_baseRange, new GUIContent("Base range"));
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Base accuracy");
                    _baseAccuracy.floatValue = EditorGUILayout.Slider(
                                _baseAccuracy.floatValue,
                                0f,
                                1f
                        );
                    EditorGUILayout.EndHorizontal();

                    break;
                }
            }
        }

        if (_typeOfItem.intValue == 2 && _isEquipable.boolValue)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Armor stats", _sectionLabel);
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(_baseDefense, new GUIContent("Base Defense"));
        }

        if (_typeOfItem.intValue == 4)
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
