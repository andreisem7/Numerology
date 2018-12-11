using System.Collections.Generic;
using System.Linq;
using static Numerology.BL.LifeCycleHelper.LifeCycleElement.LifeCyclePartElement;

namespace Numerology.BL
{
    public class LifeCycleHelper
    {
        public class LifeCycleElement
        {
            public class LifeCyclePartElement
            {
                public enum LifeCycleValuePart
                {
                    NotExisting = 0,
                    Month = 1,
                    Day = 2,
                    Year = 3
                }

                private int _floor = 0;
                private int _ceiling = 100;
                private LifeCycleValuePart _cycle;

                public int GetFloor { get { return _floor; } }
                public int GetCeiling { get { return _ceiling; } }
                public LifeCycleValuePart GetCycle { get { return _cycle; } }
                public LifeCyclePartElement(int floor, int ceiling, LifeCycleValuePart cycle)
                {
                    _floor = floor;
                    _ceiling = ceiling;
                    _cycle = cycle;
                }
            }

            private int _wayOfLife = 0;
            private List<LifeCyclePartElement> parts;

            public int GetWayOfLife { get { return _wayOfLife; } }
            public List<LifeCyclePartElement> GetParts { get { return parts; } }
            public LifeCycleElement(int wayOfLife, LifeCyclePartElement first, LifeCyclePartElement second, LifeCyclePartElement third)
            {
                _wayOfLife = wayOfLife;

                parts = new List<LifeCyclePartElement>(3);
                parts.Add(first);
                parts.Add(second);
                parts.Add(third);
            }
        }

        public static LifeCycleValuePart GetLifeCycleValuePart(int wayOfLife, int age)
        {
            var elements = GetLifeCycleElements();
            var element = elements.SingleOrDefault(x => x.GetWayOfLife == wayOfLife);

            if (element == null) return LifeCycleValuePart.NotExisting;

            var parts = element.GetParts;
            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i].GetFloor <= age && parts[i].GetCeiling >= age)
                {
                    return parts[i].GetCycle;
                }
            }

            return LifeCycleValuePart.NotExisting;
        }
        public static List<LifeCycleElement> GetLifeCycleElements()
        {
            var lifeCycleElements = new List<LifeCycleElement>(9);

            lifeCycleElements.Add(new LifeCycleElement(1,
                new LifeCycleElement.LifeCyclePartElement(0, 26, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(27, 53, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(54, 100, LifeCycleValuePart.Year)));

            lifeCycleElements.Add(new LifeCycleElement(2,
                new LifeCycleElement.LifeCyclePartElement(0, 25, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(26, 52, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(53, 100, LifeCycleValuePart.Year)));

            lifeCycleElements.Add(new LifeCycleElement(3,
                new LifeCycleElement.LifeCyclePartElement(0, 33, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(34, 60, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(61, 100, LifeCycleValuePart.Year)));

            lifeCycleElements.Add(new LifeCycleElement(4,
                new LifeCycleElement.LifeCyclePartElement(0, 32, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(33, 59, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(60, 100, LifeCycleValuePart.Year)));

            lifeCycleElements.Add(new LifeCycleElement(5,
                new LifeCycleElement.LifeCyclePartElement(0, 31, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(32, 58, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(59, 100, LifeCycleValuePart.Year)));

            lifeCycleElements.Add(new LifeCycleElement(6,
                new LifeCycleElement.LifeCyclePartElement(0, 30, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(31, 57, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(58, 100, LifeCycleValuePart.Year)));

            lifeCycleElements.Add(new LifeCycleElement(7,
                new LifeCycleElement.LifeCyclePartElement(0, 29, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(30, 56, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(57, 100, LifeCycleValuePart.Year)));

            lifeCycleElements.Add(new LifeCycleElement(8,
                new LifeCycleElement.LifeCyclePartElement(0, 28, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(29, 55, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(56, 100, LifeCycleValuePart.Year)));

            lifeCycleElements.Add(new LifeCycleElement(9,
                new LifeCycleElement.LifeCyclePartElement(0, 27, LifeCycleValuePart.Month),
                new LifeCycleElement.LifeCyclePartElement(28, 54, LifeCycleValuePart.Day),
                new LifeCycleElement.LifeCyclePartElement(55, 100, LifeCycleValuePart.Year)));

            return lifeCycleElements;
        }
    }
}
