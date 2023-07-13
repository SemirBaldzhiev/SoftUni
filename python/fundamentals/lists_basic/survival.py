nums = [int(x) for x in input().split(' ')]
n = int(input())
old_nums = list(nums)
nums.sort()
new_nums = nums[n:]
res = []
for i in range(0, len(old_nums)):
    for j in range(0, len(new_nums)):
        if old_nums[i] == new_nums[j]:
            res.append(old_nums[i])
res_str = ', '.join(str(x) for x in res)
print(res_str)