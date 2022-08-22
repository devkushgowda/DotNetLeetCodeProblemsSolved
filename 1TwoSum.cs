using System.Collections.Generic;

namespace DotNetLeetCodeProblemsSolved
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum/
    /// </summary>
    public class _1TwoSum
    {  
        /// <summary>
        /// https://www.youtube.com/watch?v=KLlXCFG5TnA
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SolveHashMapMethod(int[] nums, int target)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                var currentNum = nums[i];
                var remainingSum = target - currentNum;
                var resultList = new List<int>();
                if (map.TryGetValue(remainingSum, out resultList))
                {
                    foreach (var index in resultList)
                    {
                        if (index != i)
                            return new[] { i, index };
                    }
                }

                if (map.ContainsKey(nums[i]))
                    map[nums[i]].Add(i);
                else
                    map[nums[i]] = new List<int> { i };
            }
            return null;
        }

        /// <summary>
        /// Bruteforce method.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SolveBruteforce(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }
            return null;
        }
    }
}

/*
 * 1. Two Sum
Easy

 Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

 

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

var res = new _1TwoSum().SolveHashMapMethod(new[] { 2, 7, 11, 15 }, 9);


Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 

Constraints:

2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
 

Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
 */
