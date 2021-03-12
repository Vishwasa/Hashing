class Solution {
    public List<int> solve(List<int> A, List<int> B) {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        List<int> output = new List<int>();
        var lenA=A.Count();
        var lenB = B.Count();
        for(int i=0; i<lenA; i++){
            if(!dict.ContainsKey(A[i])){
                List<int> indices = new List<int>();
                indices.Add(i);
                dict.Add(A[i], indices);
            }
            else{
                var list = dict[A[i]];
                list.Add(i);
                //Console.WriteLine("TestDictionaryList:"+dict[A[i]][1]);
                //dict[A[i]] = list;
                //Console.WriteLine("AfterList:"+dict[A[i]][1]);
            }
        }
        for(int i=0; i<lenB; i++){
            if(dict.ContainsKey(B[i])){
                output.Add(B[i]);
                var list = dict[B[i]];
                if(list.Count==1){
                    dict.Remove(B[i]);
                }
                else{
                    list.RemoveAt(list.Count-1);
                    //dict[B[i]]=list;
                }
            }
        }
        return output;
    }
}
