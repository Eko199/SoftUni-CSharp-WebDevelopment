function arePalindromes(nums) {
    for (let num of nums) {
        console.log(isPalindrome(num));
    }

    function isPalindrome(num) {
        const str = num + '';
    
        for (let i = 0; i < str.length / 2; i++) {
            if (str[i] !== str[str.length - 1 - i])
                return false;
        }
    
        return true;
    }
}