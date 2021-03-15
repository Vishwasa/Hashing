class Solution {
    public int solve(List<int> A) {
        long sum=0;
        int lenA= A.Count();
        HashSet<long> PrefixSumSet = new HashSet<long>();
        for(int i=0; i<lenA; i++){
            sum+=A[i];
            //Console.WriteLine("ArrayElement:"+i);
            if(PrefixSumSet.Contains(sum) || sum==0){
                return 1;
            }
            else
            {
                //Console.WriteLine("PrefixSetElement:"+sum);
                PrefixSumSet.Add(sum);
            }
        }
        return 0;
    }
}
