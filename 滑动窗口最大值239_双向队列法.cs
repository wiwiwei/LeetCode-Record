
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var ans = new int[nums.Length - k + 1];
        if (k == 1) return nums;
        if (k == nums.Length) 
        {
            var a = 0;
            for(int i=0;i<nums.Length;i++)
            {
                a = Math.Max(a,nums[i]);
            }
            return new int[] { a };
        }
        var numList = nums.ToList();
        var tempList = new List<int>();
        var temp = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            if(tempList.Count==0)
            {
                tempList.Add(i);
            }
            else
            {
                while(tempList.Count!=0&&nums[i]>=nums[tempList.Last()])
                {
                    tempList.Remove(tempList.Last());
                }
                tempList.Add(i);
            }
            if(tempList[0]<i-k+1)
            {
                tempList.Remove(tempList[0]);
            }
            if(i-k+1>=0)
            {
                ans[i-k+1] = nums[tempList[0]];
            }
        }
        return ans;
    }
}