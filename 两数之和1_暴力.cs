/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int a = 0;
        int b = 0;
        foreach(var value in nums)
        {
            b=0;
            foreach(var values in nums)
            {
                if(value+values==target&&a!=b)
                {
                    return new int[]{a,b};
                }
                b++;
            }
            a++;
        }
        return new int[]{a,b};
    }
}

