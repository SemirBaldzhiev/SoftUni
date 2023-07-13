def sum_digits(n: int) -> str:
    sum_even = 0
    sum_odd = 0
    while(n > 0):
        dig = n % 10
        n //=10
        if dig % 2 == 0: sum_even+=dig
        else: sum_odd+=dig

    return f'Odd sum = {sum_odd}, Even sum = {sum_even}'

n = int(input())
print(sum_digits(n))