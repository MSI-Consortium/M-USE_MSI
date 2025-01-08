/*
MIT License

Copyright (c) 2023 Multitask - Unified - Suite -for-Expts

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files(the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ConfigDynamicUI
{

	public class ConfigUI : MonoBehaviour
	{
		[HideInInspector] public ConfigVarStore config_var_store;
		public Transform varUIContainer;

		public List<GameObject> listGeneratedObjects = new List<GameObject>();

		//UI Hotkeys
		List<Selectable> m_orderedSelectables = new List<Selectable>();

		// UI - prefabs
		public GameObject prefabNumberInput;
		public GameObject prefabSlider;
		public GameObject prefabSlider2;
		public GameObject prefabSlider3;
		public GameObject prefabBoolean;

		public void clear()
		{
			config_var_store.clear();
			foreach (GameObject g in this.listGeneratedObjects)
			{
				Destroy(g);
			}

			listGeneratedObjects.Clear();
		}


		public void GenerateUI()
		{
			foreach (var v in config_var_store.getAllVariables())
			{
				GameObject g = null;
				if (v.hidden)
					continue;
				if (v is ConfigNumber)
				{
					//Debug.Log("Generating config ui for " + v.name + " is of type: " + v.GetType());
					var f = (ConfigNumber)v;
					if (f.isRange)
					{
						g = GenerateSlider(f);
					}
					else
					{
						g = GenerateNumberInput(f);
					}
				}
				else if (v is ConfigNumberRanged)
				{
					var f = (ConfigNumberRanged)v;
					g = GenerateSlider2(f);
				}
				else if (v is ConfigNumberRangedInt)
				{
					var f = (ConfigNumberRangedInt)v;
					g = GenerateSlider3(f);
				}
				else if (v is ConfigBoolean)
				{
					var b = (ConfigBoolean)v;
					g = GenerateBoolean(b);
				}

				if (g != null)
					listGeneratedObjects.Add(g);
			}
		}

		public GameObject GenerateBoolean(ConfigBoolean b)
		{
			GameObject n = Instantiate(prefabBoolean);
			n.transform.SetParent(varUIContainer, false);
			UIBoolean ui = n.GetComponent<UIBoolean>();
			ui.setConfigVar(b);
			n.SetActive(true);
			return n;
		}

		public GameObject GenerateSlider(ConfigNumber f)
		{
			GameObject n = Instantiate(prefabSlider);
			n.transform.SetParent(varUIContainer, false);
			UIRange ui = n.GetComponent<UIRange>();
			ui.setConfigVar(f);
			n.SetActive(true);
			return n;
		}


		public GameObject GenerateSlider2(ConfigNumberRanged f)
		{
			GameObject n = Instantiate(prefabSlider2);
			n.transform.SetParent(varUIContainer, false);
			UIRange2 ui = n.GetComponent<UIRange2>();
			ui.setConfigVar(f);
			n.SetActive(true);
			return n;
		}

		public GameObject GenerateSlider3(ConfigNumberRangedInt f)
		{
			GameObject n = Instantiate(prefabSlider3);
			n.transform.SetParent(varUIContainer, false);
			UIRange2Int ui = n.GetComponent<UIRange2Int>();
			ui.setConfigVar(f);
			n.SetActive(true);
			return n;
		}

		public GameObject GenerateNumberInput(ConfigNumber f)
		{
			GameObject n = Instantiate(prefabNumberInput);
			n.transform.SetParent(varUIContainer, false);
			UINumber ui = n.GetComponent<UINumber>();
			ui.setConfigVar(f);
			n.SetActive(true);
			return n;
		}

		// Helper functions to create, get/set values of specific types


		public void SelectRandomValueForAllNumbers()
		{
			foreach (var f in config_var_store.varsNumberRanged.Values)
			{
				f.SetRandomValue();
			}

			foreach (var f in config_var_store.varsNumberRangedInt.Values)
			{
				f.SetRandomValue();
			}
		}

		public float GetFloat(string variableName)
		{
			return (float)config_var_store.get<ConfigNumber>(variableName).value;
		}

		public int GetInt(string variableName)
		{
			return (int)config_var_store.get<ConfigNumber>(variableName).value;
		}

		public void SetRandomValueMono(string variableName)
		{
			config_var_store.get<ConfigNumber>(variableName).SetRandomValue();
		}

		public float GetFloatRanged(string variableName)
		{
			return (float)config_var_store.get<ConfigNumberRanged>(variableName).value;
		}

		public int GetIntRanged(string variableName)
		{
			return (int)config_var_store.get<ConfigNumberRangedInt>(variableName).value;
		}

		public bool GetBool(string variableName)
		{
			return config_var_store.get<ConfigBoolean>(variableName).value;
		}

		public string GetString(string variableName)
		{
			return config_var_store.get<ConfigString>(variableName).value;
		}

		public ConfigNumber CreateNumber(string name, int value = 0)
		{
			ConfigNumber n = new ConfigNumber(name, value);
			config_var_store.putVar(n);
			return n;
		}

		public ConfigNumber CreateNumber(string name, float value = 0)
		{
			ConfigNumber n = new ConfigNumber(name, value).SetPrecision(2);
			config_var_store.putVar(n);
			return n;
		}

		public ConfigNumberRanged CreateNumberRanged(string name, float minvalue = 0, float maxvalue = 0)
		{
			ConfigNumberRanged n = new ConfigNumberRanged(name, minvalue, maxvalue).SetPrecision(2);
			config_var_store.putVar(n);
			return n;
		}

		public ConfigNumberRangedInt CreateNumberRangedInt(string name, int minvalue = 0, int maxvalue = 0)
		{
			ConfigNumberRangedInt n = new ConfigNumberRangedInt(name, minvalue, maxvalue);
			config_var_store.putVar(n);
			return n;
		}

		public ConfigString CreateString(string name, string value = "")
		{
			ConfigString v = new ConfigString(name, value);
			config_var_store.putVar(v);
			return v;
		}

		public ConfigBoolean CreateBoolean(string name, bool value = false)
		{
			ConfigBoolean v = new ConfigBoolean(name, value);
			config_var_store.putVar(v);
			return v;
		}

		//HotKey Methods
		public void HandleHotkeySelect(bool _isNavigateBackward, bool _isWrapAround, bool _isEnterSelect)
		{
			SortSelectables();

			GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
			if (selectedObject != null &&
			    selectedObject.activeInHierarchy) // Ensure a selection exists and is not an inactive object.
			{
				Selectable currentSelection = selectedObject.GetComponent<Selectable>();
				if (currentSelection != null)
				{
					if (_isEnterSelect)
					{
						if (currentSelection.GetComponent<InputField>() != null)
						{
							ApplyEnterSelect(FindNextSelectable(m_orderedSelectables.IndexOf(currentSelection),
								_isNavigateBackward, _isWrapAround));
						}
						else if (currentSelection.GetComponent<Button>() != null)
						{
							currentSelection.GetComponent<Button>().onClick.Invoke();
						}
					}
					else // Tab select.
					{
						Selectable nextSelection = FindNextSelectable(m_orderedSelectables.IndexOf(currentSelection),
							_isNavigateBackward, _isWrapAround);
						if (nextSelection != null)
						{
							nextSelection.Select();
						}
					}
				}
				else
				{
					SelectFirstSelectable(_isEnterSelect);
				}
			}
			else
			{
				SelectFirstSelectable(_isEnterSelect);
			}
		}

		///<summary> Selects an input field or button, activating the button if one is found. </summary>
		public void ApplyEnterSelect(Selectable _selectionToApply)
		{
			if (_selectionToApply != null)
			{
				if (_selectionToApply.GetComponent<InputField>() != null)
				{
					_selectionToApply.Select();
				}
				else
				{
					Button selectedButton = _selectionToApply.GetComponent<Button>();
					if (selectedButton != null)
					{
						_selectionToApply.Select();
						selectedButton.OnPointerClick(new PointerEventData(EventSystem.current));
					}
				}
			}
		}

		public void SelectFirstSelectable(bool _isEnterSelect)
		{
			if (m_orderedSelectables.Count > 0)
			{
				Selectable firstSelectable = m_orderedSelectables[0];
				if (_isEnterSelect)
				{
					ApplyEnterSelect(firstSelectable);
				}
				else
				{
					firstSelectable.Select();
				}
			}
		}

		public Selectable FindNextSelectable(int _currentSelectableIndex, bool _isNavigateBackward, bool _isWrapAround)
		{
			Selectable nextSelection = null;

			int totalSelectables = m_orderedSelectables.Count;
			if (totalSelectables > 1)
			{
				if (_isNavigateBackward)
				{
					if (_currentSelectableIndex == 0)
					{
						nextSelection = (_isWrapAround) ? m_orderedSelectables[totalSelectables - 1] : null;
					}
					else
					{
						nextSelection = m_orderedSelectables[_currentSelectableIndex - 1];
					}
				}
				else // Navigate forward.
				{
					if (_currentSelectableIndex == (totalSelectables - 1))
					{
						nextSelection = (_isWrapAround) ? m_orderedSelectables[0] : null;
					}
					else
					{
						nextSelection = m_orderedSelectables[_currentSelectableIndex + 1];
					}
				}
			}

			return (nextSelection);
		}

		public void SortSelectables()
		{
			List<Selectable> originalSelectables = Selectable.allSelectables;
			int totalSelectables = originalSelectables.Count;
			m_orderedSelectables = new List<Selectable>(totalSelectables);
			var buttons = new List<Selectable>(totalSelectables);
			for (int index = 0; index < totalSelectables; ++index)
			{
				Selectable selectable = originalSelectables[index];
				if (selectable.GetComponent<Button>() == null)
				{
					m_orderedSelectables.Insert(
						FindSortedIndexForSelectable(m_orderedSelectables.Count, selectable, m_orderedSelectables),
						selectable);
				}
				else
				{
					buttons.Insert(FindSortedIndexForSelectable(buttons.Count, selectable, buttons), selectable);
				}
			}

			foreach (Selectable s in buttons)
			{
				m_orderedSelectables.Add(s);
			}

		}

		///<summary> Recursively finds the sorted index by positional order within m_orderedSelectables (positional order is determined from left-to-right followed by top-to-bottom). </summary>
		public int FindSortedIndexForSelectable(int _selectableIndex, Selectable _selectableToSort,
			List<Selectable> orderedSelectables)
		{
			int sortedIndex = _selectableIndex;
			if (_selectableIndex > 0)
			{
				int previousIndex = _selectableIndex - 1;
				Vector3 previousSelectablePosition = orderedSelectables[previousIndex].transform.position;
				Vector3 selectablePositionToSort = _selectableToSort.transform.position;

				if (previousSelectablePosition.y == selectablePositionToSort.y)
				{
					if (previousSelectablePosition.x > selectablePositionToSort.x)
					{
						// Previous selectable is in front, try the previous index:
						sortedIndex =
							FindSortedIndexForSelectable(previousIndex, _selectableToSort, orderedSelectables);
					}
				}
				else if (previousSelectablePosition.y < selectablePositionToSort.y)
				{
					// Previous selectable is in front, try the previous index:
					sortedIndex = FindSortedIndexForSelectable(previousIndex, _selectableToSort, orderedSelectables);
				}
			}

			return (sortedIndex);
		}
	}

	public class config_ui_var
	{
		// public string Name;
		public object ReferencedVar;
		public Type VarType;
		public string LabelText;
		public string DefaultValue;
		public string HoverText;
		public GameObject G_object;
		public Canvas Canvas;
		private TMP_InputField InputField;
		private TMP_Text Label;
		public int Line;
		public int Column;
		public int ColWidthPix, RowHeightPix;

		public config_ui_var(object var, Type t, string label)
		{
			ReferencedVar = var;
			VarType = t;
			LabelText = label;
		}

		public config_ui_var(object var, Type t, string label, int line)
		{
			ReferencedVar = var;
			VarType = t;
			LabelText = label;
			Line = line;
		}

		public config_ui_var(object var, Type t, string label, int line, int column)
		{
			ReferencedVar = var;
			VarType = t;
			LabelText = label;
			Line = line;
			Column = column;
		}

		public T GetVal<T>()
		{
			return (T)ReferencedVar;
		}

		public void CreateAndPlace()
		{
			// 1. Create an empty parent GameObject
			G_object = new GameObject($"UIElement_{LabelText}");

			// 2. Make G_object a child of the Canvas
			G_object.transform.SetParent(Canvas.transform, false);

			// 3. Configure G_object's RectTransform for top-left anchoring
			RectTransform parentRect = G_object.AddComponent<RectTransform>();
			// Anchor top-left
			parentRect.anchorMin = new Vector2(0, 1);
			parentRect.anchorMax = new Vector2(0, 1);
			// Pivot top-left
			parentRect.pivot = new Vector2(0, 1);

			// 4. Position G_object at (Column * ColWidthPix, Line * RowHeightPix) from the top-left
			//    Note: y is negative because UI coordinates in Unity go down from the top
			parentRect.anchoredPosition = new Vector2(Column * ColWidthPix, -Line * RowHeightPix);

			// =============================
			// 5. Create the Label child
			// =============================
			GameObject labelGO = new GameObject("Label");
			labelGO.transform.SetParent(G_object.transform, false);

			// Add a RectTransform and set its size
			RectTransform labelRect = labelGO.AddComponent<RectTransform>();
			labelRect.sizeDelta = new Vector2(300f, 50f);
			labelRect.anchorMin = Vector2.zero;
			labelRect.anchorMax = Vector2.zero;
			labelRect.pivot = new Vector2(0, 1); // So that (0,0,0) means top-left corner
			labelRect.anchoredPosition = Vector2.zero; // local position (0,0,0)

			// Add a TextMeshProUGUI for displaying text
			Label = labelGO.AddComponent<TextMeshProUGUI>();
			Label.text = LabelText;
			Label.fontSize = 36;
			// If you have a reference to the LiberationSans SDF font, assign it here, e.g.:
			// Label.font = Resources.Load<TMP_FontAsset>("LiberationSans SDF");
			// Right-justify the text
			Label.alignment = TextAlignmentOptions.Right;

			// =============================
			// 6. Create the InputField child
			// =============================
			GameObject inputFieldGO = new GameObject("InputField");
			inputFieldGO.transform.SetParent(G_object.transform, false);

			// Add a RectTransform and set its size & position
			RectTransform inputRect = inputFieldGO.AddComponent<RectTransform>();
			inputRect.sizeDelta = new Vector2(80f, 30f);
			inputRect.anchorMin = Vector2.zero;
			inputRect.anchorMax = Vector2.zero;
			inputRect.pivot = new Vector2(0, 1);
			// Position at (310,15) local to G_object
			inputRect.anchoredPosition = new Vector2(310f, -15f);

			// Add the TMP_InputField component
			InputField = inputFieldGO.AddComponent<TMP_InputField>();

			// For TMP_InputField to work properly, we also need:
			//   - A TextMeshProUGUI child for the text viewport
			//   - A TextMeshProUGUI child for the placeholder
			// The simplest way is to use the built-in UI prefabs or manually create child objects.
			// But for brevity, here's a quick manual setup:
			// --------------------------------------------------------------------------
			//  Make a child GameObject for the text 'Viewport'
			var viewportGO = new GameObject("Text Area");
			viewportGO.transform.SetParent(inputFieldGO.transform, false);
			RectTransform viewportRect = viewportGO.AddComponent<RectTransform>();
			viewportRect.anchorMin = Vector2.zero;
			viewportRect.anchorMax = Vector2.one;
			viewportRect.sizeDelta = Vector2.zero;
			viewportRect.pivot = new Vector2(0, 1);

			//  The actual text shown in the input field
			var textGO = new GameObject("Text");
			textGO.transform.SetParent(viewportGO.transform, false);
			var textRect = textGO.AddComponent<RectTransform>();
			textRect.anchorMin = Vector2.zero;
			textRect.anchorMax = Vector2.one;
			textRect.sizeDelta = Vector2.zero;
			textRect.pivot = new Vector2(0, 1);

			var textComponent = textGO.AddComponent<TextMeshProUGUI>();
			textComponent.fontSize = 24;
			// textComponent.font = Resources.Load<TMP_FontAsset>("LiberationSans SDF");
			textComponent.text = DefaultValue;
			textComponent.enableWordWrapping = false;
			textComponent.alignment = TextAlignmentOptions.Left;

			// Attach text component to input field
			InputField.textViewport = viewportRect;
			InputField.textComponent = textComponent;
			InputField.text = DefaultValue;

			//  Optional placeholder
			var placeholderGO = new GameObject("Placeholder");
			placeholderGO.transform.SetParent(viewportGO.transform, false);
			var placeholderRect = placeholderGO.AddComponent<RectTransform>();
			placeholderRect.anchorMin = Vector2.zero;
			placeholderRect.anchorMax = Vector2.one;
			placeholderRect.sizeDelta = Vector2.zero;
			placeholderRect.pivot = new Vector2(0, 1);

			var placeholderText = placeholderGO.AddComponent<TextMeshProUGUI>();
			placeholderText.text = "Enter value...";
			placeholderText.fontSize = 24;
			// placeholderText.font = Resources.Load<TMP_FontAsset>("LiberationSans SDF");
			placeholderText.color = new Color(0.5f, 0.5f, 0.5f, 0.75f);
			placeholderText.alignment = TextAlignmentOptions.Left;

			InputField.placeholder = placeholderText;

			// =============================
			// 7. Add HoverText for Label
			// =============================
			// You could implement a hover tooltip by adding a script that implements
			// IPointerEnterHandler, IPointerExitHandler, or using any pre-made tooltip system.
			// For demonstration, here's a minimal placeholder approach:
			// TooltipOnHover tooltip = labelGO.AddComponent<TooltipOnHover>();
			// tooltip.HoverText = HoverText;

		}
	}
}