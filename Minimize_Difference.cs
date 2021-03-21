class Solution {
    public int solve(List<int> A, int B) {
        A.Sort();
        var len=A.Count;
        var Map = new Dictionary<int,int>();
        int max=A[0];
        int min=A[0];
        for(int i=0; i<len; i++){
           max= Math.Max(max, A[i]);
           min= Math.Min(min, A[i]);
           if(Map.ContainsKey(A[i]))
           {
               Map[A[i]]++;
           }
           else{
               Map.Add(A[i],1);
           }
        }
        //Console.WriteLine("min: "+min+" max:: "+max);
        List<int> getKeys = new List<int>();
        foreach(int i in Map.Keys)
        {
            getKeys.Add(i);
        }
        /*
        for(int i=0; i<getKeys.Count(); i++)
        {
            Console.WriteLine("i:"+i);
            Console.WriteLine(getKeys[0]+"dictionary Key:A[i]:"+getKeys[i]);
            //var tmpkey = A[i];
            Console.WriteLine(":dictValue:"+Map[getKeys[i]]);
        }
        */

        
        int keyMin=0, keyMax=getKeys.Count()-1;
        //Console.WriteLine(keyMin+":keyMax:"+keyMax+"::B::"+B);
        while(B>0 && max>=min){
            //Console.WriteLine(Map[max]+":max<-Map->min:"+Map[min]);
            if(Map[max]>=Map[min]){
                if(B<Map[min]){
                    break;
                }
                keyMin++;
                var nextMin = getKeys[keyMin];
                var possibleMaxdiff = nextMin - min;
                if(B >= possibleMaxdiff*Map[min]){
                    Map[nextMin]+=Map[min];
                    B-=possibleMaxdiff*Map[min];
                    min = nextMin;
                }
                else{
                    int tempValue =Map[min]; 
                    min = min + B/tempValue;
                    break;
                }
            /*    //Map[min+1]+=Map[min];
               if(Map.ContainsKey(min+1))
               {
                   Map[min+1]+=Map[min];
               }
               else{
                   Map.Add(min+1,Map[min]);
               }
               B=B-Map[min];
                min++;
                 */
            }
            else{
                if(Map[max]<Map[min]){
                    if(B<Map[max]){
                        break;
                    }
                    keyMax--;
                    var nextMax = getKeys[keyMax];
                    var possibleMaxdiff = max - nextMax;
                    if(B >= possibleMaxdiff*Map[max]){
                        Map[nextMax]+=Map[max];
                        B-=possibleMaxdiff*Map[max];
                        max = nextMax;
                    }
                    else{
                        int tempValue = B/Map[max];
                        max = max - tempValue;
                        break;
                    }
                    /*if(Map.ContainsKey(max-1))
                       {
                           Map[max-1]+=Map[max];
                       }
                       else{
                           Map.Add(max-1,Map[max]);
                       }
                    //Map[max-1]+=Map[max];
                    B=B-Map[max];
                    max--;
                    */
                }
            }
        }
        //Console.WriteLine("max:"+max+" min:"+min);
        return (max-min)<0? 0: max-min;
    }
}
