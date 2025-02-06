using System.Collections.Generic;

namespace GaleShapely
{
    public class StableMarriageSolver
    {
        public static Dictionary<string, string> Solve(Dictionary<string, List<string>> menPreferences, Dictionary<string, List<string>> womenPreferences)
        {
            Dictionary<string, Queue<string>> menQueues = new Dictionary<string, Queue<string>>();
            foreach (KeyValuePair<string, List<string>> kvp in menPreferences)
            {
                menQueues[kvp.Key] = new Queue<string>(kvp.Value);
            }

            Dictionary<string, Dictionary<string, int>> womenRankings = new Dictionary<string, Dictionary<string, int>>();
            foreach (KeyValuePair<string, List<string>> kvp in womenPreferences)
            {
                Dictionary<string, int> ranking = new Dictionary<string, int>();
                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    ranking[kvp.Value[i]] = i;
                }

                womenRankings[kvp.Key] = ranking;
            }

            Dictionary<string, string> engagements = new Dictionary<string, string>();
            Queue<string> freeMen = new Queue<string>();
            foreach (string man in menPreferences.Keys)
            {
                freeMen.Enqueue(man);
            }

            while (freeMen.Count > 0)
            {
                string man = freeMen.Dequeue();
                if (menQueues[man].Count == 0)
                {
                    continue;
                }

                string woman = menQueues[man].Dequeue();
                if (!engagements.ContainsKey(woman))
                {
                    engagements[woman] = man;
                }
                else
                {
                    string currentMan = engagements[woman];
                    Dictionary<string, int> ranking = womenRankings[woman];
                    if (ranking[man] < ranking[currentMan])
                    {
                        engagements[woman] = man;
                        if (menQueues[currentMan].Count > 0)
                        {
                            freeMen.Enqueue(currentMan);
                        }
                    }
                    else
                    {
                        if (menQueues[man].Count > 0)
                        {
                            freeMen.Enqueue(man);
                        }
                    }
                }
            }

            Dictionary<string, string> matches = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in engagements)
            {
                matches[kvp.Value] = kvp.Key;
            }

            return matches;
        }
    }
}