public class Solution {
    public int SingleNumber(int[] nums) {
        int res = 0;
        for(int i=0; i<nums.Length; i++){
            res ^= nums[i];
        }
        return res;
    }
}
