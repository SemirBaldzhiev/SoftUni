l = input().split(' ')
n = int(input())
res = l
curr = []
for _ in range(0, n):
    for (a, b) in zip(res[0:len(res)//2], res[len(res)//2:]):
        curr.append(a)
        curr.append(b)
    res = curr
    curr = []

print(res)