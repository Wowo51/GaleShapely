using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GaleShapely;

namespace GaleShapelyTest
{
    [TestClass]
    public class StableMarriageSolverTests
    {
        [TestMethod]
        public void BasicStableMatchTest()
        {
            Dictionary<string, List<string>> menPreferences = new Dictionary<string, List<string>>();
            menPreferences["m1"] = new List<string>
            {
                "w1",
                "w2"
            };
            menPreferences["m2"] = new List<string>
            {
                "w2",
                "w1"
            };
            Dictionary<string, List<string>> womenPreferences = new Dictionary<string, List<string>>();
            womenPreferences["w1"] = new List<string>
            {
                "m1",
                "m2"
            };
            womenPreferences["w2"] = new List<string>
            {
                "m2",
                "m1"
            };
            Dictionary<string, string> matches = StableMarriageSolver.Solve(menPreferences, womenPreferences);
            Dictionary<string, string> expected = new Dictionary<string, string>();
            expected["m1"] = "w1";
            expected["m2"] = "w2";
            Assert.AreEqual(expected.Count, matches.Count);
            foreach (KeyValuePair<string, string> pair in expected)
            {
                Assert.IsTrue(matches.ContainsKey(pair.Key));
                Assert.AreEqual(pair.Value, matches[pair.Key]);
            }
        }

        [TestMethod]
        public void UnmatchedTest()
        {
            Dictionary<string, List<string>> menPreferences = new Dictionary<string, List<string>>();
            menPreferences["m1"] = new List<string>
            {
                "w1"
            };
            menPreferences["m2"] = new List<string>
            {
                "w1"
            };
            Dictionary<string, List<string>> womenPreferences = new Dictionary<string, List<string>>();
            womenPreferences["w1"] = new List<string>
            {
                "m2",
                "m1"
            };
            Dictionary<string, string> matches = StableMarriageSolver.Solve(menPreferences, womenPreferences);
            Dictionary<string, string> expected = new Dictionary<string, string>();
            expected["m2"] = "w1";
            Assert.AreEqual(expected.Count, matches.Count);
            foreach (KeyValuePair<string, string> pair in expected)
            {
                Assert.IsTrue(matches.ContainsKey(pair.Key));
                Assert.AreEqual(pair.Value, matches[pair.Key]);
            }
        }

        [TestMethod]
        public void EmptyPreferencesTest()
        {
            Dictionary<string, List<string>> menPreferences = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> womenPreferences = new Dictionary<string, List<string>>();
            Dictionary<string, string> matches = StableMarriageSolver.Solve(menPreferences, womenPreferences);
            Assert.AreEqual(0, matches.Count);
        }

        [TestMethod]
        public void SwapTest()
        {
            Dictionary<string, List<string>> menPreferences = new Dictionary<string, List<string>>();
            menPreferences["m1"] = new List<string>
            {
                "w1",
                "w2"
            };
            menPreferences["m2"] = new List<string>
            {
                "w1",
                "w2"
            };
            Dictionary<string, List<string>> womenPreferences = new Dictionary<string, List<string>>();
            womenPreferences["w1"] = new List<string>
            {
                "m2",
                "m1"
            };
            womenPreferences["w2"] = new List<string>
            {
                "m1",
                "m2"
            };
            Dictionary<string, string> matches = StableMarriageSolver.Solve(menPreferences, womenPreferences);
            Dictionary<string, string> expected = new Dictionary<string, string>();
            expected["m2"] = "w1";
            expected["m1"] = "w2";
            Assert.AreEqual(expected.Count, matches.Count);
            foreach (KeyValuePair<string, string> pair in expected)
            {
                Assert.IsTrue(matches.ContainsKey(pair.Key));
                Assert.AreEqual(pair.Value, matches[pair.Key]);
            }
        }
    }
}