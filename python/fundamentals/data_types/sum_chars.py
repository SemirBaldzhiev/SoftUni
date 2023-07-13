n = int(input())
sum = 0
for i in range(0, n):
    ch = input()
    sum += ord(ch)
print(f'The sum equals: {sum}')