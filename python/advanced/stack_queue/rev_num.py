numbers = input().split(' ')
rev_nums = list()
l = len(numbers)

for _ in range(l):
    rev_nums.append(numbers.pop())
print(*rev_nums)