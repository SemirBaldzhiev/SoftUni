def is_perfect(num: int) -> bool:
    sum_div = 0
    for i in range(1, num):
        if num % i == 0: sum_div+=i
    return sum_div == num

num = int(input())
if is_perfect(num): print('We have a perfect number!')
else: print('It\'s not so perfect.')