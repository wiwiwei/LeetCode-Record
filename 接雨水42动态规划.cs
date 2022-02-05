public class Solution 
{
    public int Trap(int[] height) {
        int ans = 0;
        var leftMax = new int[height.Count()];
        var rightMax = new int[height.Count()];
        for (int i = 1; i < height.Count()-1; i++)
        {
            leftMax[i] = Math.Max(height[i-1],leftMax[i-1]);//它前边的墙的左边的最高高度和它前边的墙的高度选一个较大的，就是当前列左边最高的墙了。
        }
        for (int i = height.Count()-2; i > 0; i--)
        {
            rightMax[i] = Math.Max(height[i+1],rightMax[i+1]);//它后边的墙的右边的最高高度和它后边的墙的高度选一个较大的，就是当前列右边最高的墙了。
        }
        for(int i = 1; i < height.Count()-1; i++)
        {
            ans+=Math.Min(leftMax[i],rightMax[i])>height[i]?Math.Min(leftMax[i],rightMax[i])-height[i]:0;//需要左边和右边同时比自己高，且低的减去本身得到当前列的存水量
        }
        return ans;
    }
}
