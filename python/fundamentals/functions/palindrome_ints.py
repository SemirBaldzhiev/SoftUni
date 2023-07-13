def is_palindrome(n: int) -> bool:

    rev_num = 0
    old_n = n
    while n > 0:
        rev_num*=10
        rev_num+=n%10
        n//=10
    return rev_num == old_n

nums = [int(x) for x in input().split(', ')]

for n in nums:
    print(is_palindrome(n))