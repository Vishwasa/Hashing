class Solution {
    public int solve(List<int> A, int B) {
        HashSet<int> set = new HashSet<int>();
        int count=0;
        foreach(int i in A){
            if(set.Contains(i)){
                count++;
                set.Remove(i);
            }
            else{
                set.Add(i^B);
            }
        }
        return count;
    }
}
