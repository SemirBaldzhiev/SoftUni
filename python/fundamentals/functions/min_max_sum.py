def min_num(nums: list) -> int:
    return min(nums)
def max_num(nums: list) -> int:
    return max(nums)
def sum_nums(nums: list) -> int:
    return sum(nums)

numbers = [int(x) for x in input().split(' ')]

print(f'The minimum number is {min_num(numbers)}')
print(f'The maximum number is {max_num(numbers)}')
print(f'The sum number is: {sum_nums(numbers)}')