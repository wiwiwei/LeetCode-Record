/*
    本解法正确性是OK的，提交LeetCode只有两个要求时间的测试用例无法通过，本地测试计算结果是正确的。
    因此解为原创，所以记录一下，首先遍历数据，根据高度存一个Dictionary<int,List<int>>，高度对应位置的词典。
    将高度排序，从高到底遍历，如果对应柱子的数量为1，则无法存水，需要将高度降为递减序列中的第二高度，并且将对应位置也合并进对应的词典中，如果位于中间则不需要插入，因为只有最左边和最右边才有意义。
    当大于1时且不相邻时，意味着可以存水了，此时计算存水量，最左边到最右边的距离为底，高为当前高度，再减去柱子的面积，则为存水量，计算完成后需要把空白部分填充上，避免重复计算。
    将所有高度遍历完，得出的总和即为结果
    */
public class Solution {
    public int Trap(int[] height) {
        var dic = new Dictionary<int,List<int>>();
        for(int i=0;i<height.Length;i++)
        {
            if(dic.ContainsKey(height[i]))
            {
                dic[height[i]].Add(i);
            }
            else
            {
                dic[height[i]] = new List<int>(){i};
            }
        }//存一个Dictionary<int,List<int>>，高度对应位置的词典。
        int ans=0;
        var heightList = dic.Keys.OrderByDescending(i=>i).ToList();//将高度排序
        for(int k=0;k<heightList.Count;k++)//从高到低遍历
        {
            var maxheight = heightList[k];
            if(maxheight==0)continue;//高度为0无法存水，跳过
            if(dic[maxheight].Count>1)//大于1才能存水
            {
                var leng = dic[maxheight].Last() - dic[maxheight].First();
                if(leng!=1)//相邻时无法存水，直接跳过
                {
                    var sum = (dic[maxheight].Last() - dic[maxheight].First() + 1) * maxheight;
                    for (int j = dic[maxheight][0]; j <= dic[maxheight].Last(); j++)
                    {
                        sum = sum - (height[j] > maxheight ? maxheight : height[j]);
                        height[j] = maxheight;
                    }
                    ans += sum;//计算存水量
                }
            }
            if (k < heightList.Count - 1)//将对应位置也合并进对应的词典中，如果位于中间则不需要插入，因为只有最左边和最右边才有意义。eg：4和2中间如果有空白则可以存水，此时如果不把4插入到2中，则会出现一个2无法存水的错误判断。
            {
                if (dic[maxheight][0] < dic[heightList[k + 1]][0])
                {
                    dic[heightList[k + 1]].Insert(0, dic[maxheight][0]);
                }
                if (dic[maxheight].Last() > dic[heightList[k + 1]].Last())
                {
                    dic[heightList[k + 1]].Add(dic[maxheight].Last());
                }
            }
        }
        return ans;
    }
}