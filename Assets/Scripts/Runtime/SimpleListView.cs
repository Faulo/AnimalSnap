using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine.UIElements;

namespace Game {
    [UxmlElement]
    partial class SimpleListView : BindableElement {
        public Func<VisualElement> makeItem;

        IList _itemsSource;
        [CreateProperty]
        public IList itemsSource {
            get => _itemsSource;
            set {
                if (_itemsSource == value) {
                    Update();
                } else {
                    _itemsSource = value;
                    Rebuild();
                }
            }
        }

        int _elementsPerSection;
        [CreateProperty]
        [UxmlAttribute]
        public int elementsPerSection {
            get => _elementsPerSection;
            set {
                if (_elementsPerSection == value) {
                    return;
                }

                _elementsPerSection = value;
                Rebuild();
            }
        }

        public SimpleListView() {
            AddToClassList("simpleListView");
        }

        internal void Update() {
            int newSize = _itemsSource is null
                ? -1
                : _itemsSource.Count;

            if (builtSize != newSize) {
                Rebuild();
            }
        }

        int builtSize = -1;

        readonly List<VisualElement> sections = new();
        VisualElement GetSectionForElement(int elementIndex) {
            if (elementsPerSection == 0) {
                return this;
            }

            int sectionIndex = elementIndex / elementsPerSection;
            for (int i = sections.Count; i < sectionIndex + 1; i++) {
                var section = new VisualElement();
                Add(section);
                sections.Add(section);
            }

            return sections[sectionIndex];
        }

        readonly List<VisualElement> _elements = new();

        protected IReadOnlyList<VisualElement> elements => _elements;

        protected virtual void Rebuild() {
            sections.Clear();
            _elements.Clear();

            Clear();

            if (_itemsSource is null || makeItem is null) {
                builtSize = -1;
                return;
            }

            builtSize = 0;

            for (int i = 0; i < _itemsSource.Count; i++) {
                var element = makeItem();
                element.dataSource = _itemsSource[i];
                GetSectionForElement(i).Add(element);
                _elements.Add(element);
                builtSize++;
            }
        }
    }
}