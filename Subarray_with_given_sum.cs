class Solution {
    public List<int> solve(List<int> A, int B) {
        //foreach(int i in A){Console.WriteLine(" "+i);}
        var lenA=A.Count();
/*        if(B==null)
        {
            return new List<int>(){ -1};
        }
 */
        var prefixSumArray = new int[lenA];
        int sum=0;
        int startIndex=Int32.MaxValue;
        int endIndex=Int32.MaxValue;
        var output = new List<int>();
        for(int i=0; i<lenA; i++)
        {
            sum+=A[i];
            if(sum==B){
                //return returnFunction(0, i, ref A);
                startIndex=0;
                endIndex=i;
                //break;
            }
            prefixSumArray[i]=sum;
        }
        if(sum!=B){
            for(int i=0; i<lenA-1; i++){
                for(int j=lenA-1; j>=i; j--){
                    var tempSum = prefixSumArray[j]-prefixSumArray[i];
                    if(tempSum==B && startIndex>i+1){
                        //return returnFunction(i+1,j, ref A);
                        startIndex=i+1;
                        endIndex=j;
                    }
                }
            }
        }
        if(startIndex==Int32.MaxValue){
            return new List<int>(){ -1};
        }
        else{
            for(int i=startIndex; i<=endIndex; i++)
            {
                output.Add(A[i]);
            }
            return output;
        }
    }
    private List<int> returnFunction(int A, int B, ref List<int> arr)
    {
        var output = new List<int>();
        for(int i=A; i<=B; i++)
        {
            output.Add(arr[i]);
        }
        return output;
    }
}
