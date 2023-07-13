from math import ceil

n = int(input())
p = int(input())

cnt=n//p
if n%p > p: cnt+=ceil((n%p)/float(p))
elif n%p != 0: cnt+=1

print(cnt)