using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerology.BL
{
    public class LifeCycleManager
    {
        private List<LifeCycleViewModel> LifeCycleViewModels { get; set; }
        public void Init()
        {
            LifeCycleViewModels = new List<LifeCycleViewModel>();
            LifeCycleViewModels.Add(new LifeCycleViewModel(1, false, -1, 1, 0, 26, 2, 27, 53, 3, 54, 100));
            LifeCycleViewModels.Add(new LifeCycleViewModel(2, true, 11, 1, 0, 25, 2, 26, 52, 3, 53, 100));
            LifeCycleViewModels.Add(new LifeCycleViewModel(3, false, -1, 1, 0, 33, 2, 34, 60, 3, 61, 100));
            LifeCycleViewModels.Add(new LifeCycleViewModel(4, true, 22, 1, 0, 32, 2, 33, 59, 3, 60, 100));
            LifeCycleViewModels.Add(new LifeCycleViewModel(5, false, -1, 1, 0, 31, 2, 32, 58, 3, 59, 100));
            LifeCycleViewModels.Add(new LifeCycleViewModel(6, true, 33, 1, 0, 30, 2, 31, 57, 3, 58, 100));
            LifeCycleViewModels.Add(new LifeCycleViewModel(7, false, -1, 1, 0, 29, 2, 30, 56, 3, 57, 100));
            LifeCycleViewModels.Add(new LifeCycleViewModel(8, false, -1, 1, 0, 28, 2, 29, 55, 3, 56, 100));
            LifeCycleViewModels.Add(new LifeCycleViewModel(9, false, -1, 1, 0, 27, 2, 28, 54, 3, 55, 100));
        }

        public LifeCycleViewModel GetFinalized(DateTime dob, int lifeWayNumber, bool isMaster, int yearOfInterest)
        {
            LifeCycleViewModel viewModel = null;
            if (LifeCycleViewModels == null) return null;

            if (yearOfInterest < dob.Year) return null;

            viewModel = LifeCycleViewModels.FirstOrDefault(x => x.LifeWayNumber == lifeWayNumber);
            if (viewModel == null) return null;
            viewModel.IsMaster = isMaster;

            var yearDiffs = new List<int>();
            var prevDay = dob.AddDays(-1);
            var nextDay = dob.AddDays(1);
            if (prevDay.Year < dob.Year) // Means that dob.Date is 01.01
            {
                yearDiffs.Add(yearOfInterest - dob.Year);
            }
            else // Means that dob.Date is 31.12 or all other days in year
            {
                yearDiffs.Add((yearOfInterest - dob.Year) - 1);
                yearDiffs.Add(yearOfInterest - dob.Year);
            }

            foreach (var cycle in viewModel.Cycles.Where(x => x.IsMaster == isMaster).ToList())
            {
                cycle.Number = 0;
                cycle.IsSelected = false;
            }

            foreach (var yearDiff in yearDiffs)
            {
                foreach (var cycle in viewModel.Cycles.Where(x => x.IsMaster == isMaster).ToList())
                {
                    if (cycle.PeriodFloor <= yearDiff && cycle.PeriodCeiling >= yearDiff)
                    {
                        cycle.IsSelected = true;
                        switch (cycle.Cycle)
                        {
                            case 1: { cycle.Number = int.Parse(NarrowToOneNumber(dob.Month.ToString())); break; }
                            case 2: { cycle.Number = int.Parse(NarrowToOneNumber(dob.Day.ToString())); break; }
                            case 3: { cycle.Number = int.Parse(NarrowToOneNumber(dob.Year.ToString())); break; }
                            default: { cycle.Number = 0; break; }
                        }
                    }
                }
            }

            return viewModel;
        }
        private string SimplifyString(string input)
        {
            if (input.Length == 1) return input;

            int result = 0;
            char[] splitted = input.ToCharArray();
            for (int i = 0; i < splitted.Length; i++)
            {
                result += int.Parse(splitted[i].ToString());
            }

            return result.ToString();
        }
        private string NarrowToOneNumber(string input)
        {
            string result = input;
            while (result.Length > 1)
            {
                result = SimplifyString(result);
            }
            return result;
        }
    }
    public class LifeCycleViewModel
    {
        public int LifeWayNumber { get; set; }
        public bool IsMaster { get; set; }
        public int MasterLifeWayNumber { get; set; }
        public List<LifeCycleTagObject> Cycles { get; set; }
        public LifeCycleViewModel(
            int lifeWayNumber,
            bool isMaster,
            int masterLifeWayNumber,
            int cycle1,
            int periodFloor1,
            int periodCeiling1,
            int cycle2,
            int periodFloor2,
            int periodCeiling2,
            int cycle3,
            int periodFloor3,
            int periodCeiling3)
        {
            LifeWayNumber = lifeWayNumber;
            IsMaster = isMaster;

            Cycles = new List<LifeCycleTagObject>();
            Cycles.Add(new LifeCycleTagObject(lifeWayNumber, periodFloor1, periodCeiling1, cycle1, -1, false));
            Cycles.Add(new LifeCycleTagObject(lifeWayNumber, periodFloor2, periodCeiling2, cycle2, -1, false));
            Cycles.Add(new LifeCycleTagObject(lifeWayNumber, periodFloor3, periodCeiling3, cycle3, -1, false));

            if (IsMaster)
            {
                MasterLifeWayNumber = masterLifeWayNumber;
                Cycles.Add(new LifeCycleTagObject(lifeWayNumber, periodFloor1, periodCeiling1, cycle1, -1, true));
                Cycles.Add(new LifeCycleTagObject(lifeWayNumber, periodFloor2, periodCeiling2, cycle2, -1, true));
                Cycles.Add(new LifeCycleTagObject(lifeWayNumber, periodFloor3, periodCeiling3, cycle3, -1, true));
            }
        }
    }
}
