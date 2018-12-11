using System.Collections.Generic;
using System.Linq;

namespace Numerology.BL
{
    public class PersonalWorkingRelationshipManager
    {
        private static List<PersonalWorkingElement> _personalWorkingElements;
        public class PersonalWorkingElement
        {
            private int _lowerBound = 0;
            private int _upperBound = 0;
            private int _working = 0;
            private int _personal = 0;
            private int _personalAlternating = 0;

            public int GetLowerBound { get { return _lowerBound; } }
            public int GetUpperBound { get { return _upperBound; } }
            public int GetWorking { get { return _working; } }
            public int GetPersonal { get { return _personal; } }
            public int GetPersonalAlternating { get { return _personalAlternating; } }
            public PersonalWorkingElement(int lowerBound, int upperBound, int working, int personal, int personalAlternating)
            {
                _lowerBound = lowerBound;
                _upperBound = upperBound;
                _working = working;
                _personal = personal;
                _personalAlternating = personalAlternating;
            }
        }
        static PersonalWorkingRelationshipManager()
        {
            _personalWorkingElements = GetPersonalWorkingElements();
        }

        public static void GetPersonalWorkingValues(int first, int second, out int working, out int personal, out int personalAlternating)
        {
            working = -1;
            personal = -1;
            personalAlternating = -1;

            SortIncomingValues(first, second, out var lowerBound, out var upperBound);

            var element = _personalWorkingElements.SingleOrDefault(x => x.GetLowerBound == lowerBound && x.GetUpperBound == upperBound);
            if (element == null) return;

            working = element.GetWorking;
            personal = element.GetPersonal;
            personalAlternating = element.GetPersonalAlternating;
        }

        private static void SortIncomingValues(int first, int second, out int lower, out int upper)
        {
            lower = -1;
            upper = -1;

            if (first < second || first == second)
            {
                lower = first;
                upper = second;
            }
            else
            {
                lower = second;
                upper = first;
            }
        }
        private static List<PersonalWorkingElement> GetPersonalWorkingElements()
        {
            var elements = new List<PersonalWorkingElement>();

            // 0
            elements.Add(new PersonalWorkingElement(0, 0, 2, 1, 1));
            elements.Add(new PersonalWorkingElement(0, 1, 3, 1, 1));
            elements.Add(new PersonalWorkingElement(0, 2, 1, 3, 3));
            elements.Add(new PersonalWorkingElement(0, 3, 3, 1, 1));
            elements.Add(new PersonalWorkingElement(0, 4, 3, 1, 1));
            elements.Add(new PersonalWorkingElement(0, 5, 1, 1, 1));
            elements.Add(new PersonalWorkingElement(0, 6, 2, 2, 2));
            elements.Add(new PersonalWorkingElement(0, 7, 1, 1, 1));
            elements.Add(new PersonalWorkingElement(0, 8, 3, 2, 2));

            // 1
            elements.Add(new PersonalWorkingElement(1, 1, 3, 2, 2));
            elements.Add(new PersonalWorkingElement(1, 2, 4, 3, 3));
            elements.Add(new PersonalWorkingElement(1, 3, 3, 3, 3));
            elements.Add(new PersonalWorkingElement(1, 4, 3, 2, 2));
            elements.Add(new PersonalWorkingElement(1, 5, 4, 2, 2));
            elements.Add(new PersonalWorkingElement(1, 6, 3, 3, 3));
            elements.Add(new PersonalWorkingElement(1, 7, 2, 2, 2));
            elements.Add(new PersonalWorkingElement(1, 8, 2, 1, 1));
            elements.Add(new PersonalWorkingElement(1, 9, 3, 3, 3));

            // 2
            elements.Add(new PersonalWorkingElement(2, 2, 2, 3, 3));
            elements.Add(new PersonalWorkingElement(2, 3, 3, 3, 3));
            elements.Add(new PersonalWorkingElement(2, 4, 4, 3, 3));
            elements.Add(new PersonalWorkingElement(2, 5, 2, 2, 2));
            elements.Add(new PersonalWorkingElement(2, 6, 3, 4, 4));
            elements.Add(new PersonalWorkingElement(2, 7, 1, 3, 3));
            elements.Add(new PersonalWorkingElement(2, 8, 3, 3, 3));
            elements.Add(new PersonalWorkingElement(2, 9, 3, 3, 4));

            // 3
            elements.Add(new PersonalWorkingElement(3, 3, 1, 1, 1));
            elements.Add(new PersonalWorkingElement(3, 4, 2, 2, 2));
            elements.Add(new PersonalWorkingElement(3, 5, 3, 3, 3));
            elements.Add(new PersonalWorkingElement(3, 6, 3, 3, 3));
            elements.Add(new PersonalWorkingElement(3, 7, 2, 3, 3));
            elements.Add(new PersonalWorkingElement(3, 8, 4, 2, 2));
            elements.Add(new PersonalWorkingElement(3, 9, 1, 3, 3));

            // 4
            elements.Add(new PersonalWorkingElement(4, 4, 4, 3, 3));
            elements.Add(new PersonalWorkingElement(4, 5, 3, 2, 2));
            elements.Add(new PersonalWorkingElement(4, 6, 4, 4, 4));
            elements.Add(new PersonalWorkingElement(4, 7, 3, 3, 3));
            elements.Add(new PersonalWorkingElement(4, 8, 4, 3, 3));
            elements.Add(new PersonalWorkingElement(4, 9, 3, 2, 3));

            // 5
            elements.Add(new PersonalWorkingElement(5, 5, 2, 2, 2));
            elements.Add(new PersonalWorkingElement(5, 6, 2, 3, 3));
            elements.Add(new PersonalWorkingElement(5, 7, 1, 3, 3));
            elements.Add(new PersonalWorkingElement(5, 8, 4, 3, 3));
            elements.Add(new PersonalWorkingElement(5, 9, 3, 3, 3));

            // 6
            elements.Add(new PersonalWorkingElement(6, 6, 2, 4, 4));
            elements.Add(new PersonalWorkingElement(6, 7, 1, 2, 2));
            elements.Add(new PersonalWorkingElement(6, 8, 3, 4, 4));
            elements.Add(new PersonalWorkingElement(6, 9, 3, 3, 3));

            // 7
            elements.Add(new PersonalWorkingElement(7, 7, 2, 3, 3));
            elements.Add(new PersonalWorkingElement(7, 8, 4, 3, 3));
            elements.Add(new PersonalWorkingElement(7, 9, 2, 4, 4));

            // 8
            elements.Add(new PersonalWorkingElement(8, 8, 4, 2, 2));
            elements.Add(new PersonalWorkingElement(8, 9, 3, 4, 4));

            // 9
            elements.Add(new PersonalWorkingElement(9, 9, 2, 3, 3));

            return elements;
        }
    }
}
