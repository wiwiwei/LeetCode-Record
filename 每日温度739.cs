//暴力解法
public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var list = temperatures.ToList();
        var ans = new List<int>();
        for(int i = 0;i<list.Count;i++ )
        {
            ans.Add(0);
            for(int j=i+1;j<list.Count;j++)
            {
                if(list[j]>list[i])
                {
                    ans[i] = j-i;
                    break;
                }
            }
        }
        return ans.ToArray();
    }
}