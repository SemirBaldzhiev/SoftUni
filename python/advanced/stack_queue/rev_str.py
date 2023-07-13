stack = list(input())
rev = list()
len = len(stack)
for _ in range(len):
    rev.append(stack.pop())
res = ''.join(rev)
print(res)