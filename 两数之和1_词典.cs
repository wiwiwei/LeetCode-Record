/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
//通过词典存下已遍历过的key值，这样匹配过程就是O（1），整体时间复杂度降为O（n），空间复杂度上升为o(n),属于空间换时间
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> dic = new Dictionary<int,int>();
        for(int i = 0;i<nums.Length;i++)
        {
            if(dic.ContainsKey(target-nums[i]))
            {
                return new int[]{dic[target-nums[i]],i};
            }
            dic[nums[i]] = i;
        }
        return new int[]{0,0};
    }
}