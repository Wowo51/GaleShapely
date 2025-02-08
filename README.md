# Gale-Shapley Algorithm in C#

A pure C# library. No external dependencies except for Microsoft's unit testing. No binaries. Unit tested.

This code is free to use under the MIT.

## Overview
The Gale-Shapley algorithm, also known as the **Stable Marriage Problem**, is an algorithm that finds a stable matching between two equally sized sets of elements, given an ordering of preferences for each element. A matching is considered **stable** if there are no two elements that would rather be with each other than with their current partners.

This implementation provides a straightforward, efficient way to solve this problem using a **dictionary-based approach**.

## How the Algorithm Works
1. Each man proposes to the highest-ranked woman on his preference list who has not yet rejected him.
2. Each woman evaluates the proposal. She **accepts** the proposal if she is currently unmatched or prefers the new proposer to her current match.
3. If a woman switches to a new proposer, her previous match becomes **unmatched** and resumes proposing.
4. This process repeats until no unmatched men remain.

The result is a stable matching where no pair of elements would prefer each other over their assigned partners.

## Using the Code
### 1. Define Preferences
The algorithm requires two dictionaries:

```csharp
Dictionary<string, List<string>> menPreferences = new Dictionary<string, List<string>>
{
    { "m1", new List<string> { "w1", "w2" } },
    { "m2", new List<string> { "w2", "w1" } }
};

Dictionary<string, List<string>> womenPreferences = new Dictionary<string, List<string>>
{
    { "w1", new List<string> { "m1", "m2" } },
    { "w2", new List<string> { "m2", "m1" } }
};
```

### 2. Solve the Matching Problem
Use the `StableMarriageSolver.Solve` function to compute the stable pairs:

```csharp
Dictionary<string, string> matches = StableMarriageSolver.Solve(menPreferences, womenPreferences);
```

### 3. Output the Results
```csharp
foreach (var match in matches)
{
    Console.WriteLine($"{match.Key} is matched with {match.Value}");
}
```

## Unit Testing
The `StableMarriageSolverTests` class in `GaleShapelyTest` contains multiple test cases:
- **BasicStableMatchTest** – Ensures a correct stable matching.
- **UnmatchedTest** – Tests cases where not all participants get matched.
- **EmptyPreferencesTest** – Verifies behavior with empty preference lists.
- **SwapTest** – Ensures correctness in scenarios where preference orders cause swaps.

Example test:

```csharp
[TestMethod]
public void BasicStableMatchTest()
{
    Dictionary<string, List<string>> menPreferences = new Dictionary<string, List<string>>
    {
        { "m1", new List<string> { "w1", "w2" } },
        { "m2", new List<string> { "w2", "w1" } }
    };
    Dictionary<string, List<string>> womenPreferences = new Dictionary<string, List<string>>
    {
        { "w1", new List<string> { "m1", "m2" } },
        { "w2", new List<string> { "m2", "m1" } }
    };
    Dictionary<string, string> matches = StableMarriageSolver.Solve(menPreferences, womenPreferences);
    
    Assert.AreEqual("w1", matches["m1"]);
    Assert.AreEqual("w2", matches["m2"]);
}
```

## Conclusion
This C# implementation of the Gale-Shapley algorithm provides a robust solution to the stable marriage problem. It is optimized, unit-tested, and easy to integrate into various projects requiring stable pair matching.

![AI Image](aiimage.jpg)
Copyright [TranscendAI.tech](https://TranscendAI.tech) 2025.</br>
Authored by Warren Harding. AI assisted.</br>

