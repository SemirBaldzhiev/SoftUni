n = int(input())
contains = False
for _ in range(0, n):
    string = input()
    for c in string:
        if c == '_' or c == ',' or c == '.':
            contains = True
            break
    if contains == True: print(f'{string} is not pure!')
    else: print(f'{string} is pure.')
    contains = False