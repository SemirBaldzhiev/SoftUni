n = int(input())
matrix = []

for _ in range(n):
    matrix.append(list(input()))
symb = input()
row = 0
col = 0
found = False
for i in range(n):
    row_len = len(matrix[i])
    if found:
        break
    for j in range(row_len):
        if matrix[i][j] == symb:
            row = i
            col = j
            found = True
            break
if found:
    print(f'({row}, {col})')
else:
    print(f'{symb} does not occur in the matrix')