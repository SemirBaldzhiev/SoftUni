n = int(input())
matrix = []

for _ in range(n):
    matrix.append(list(map(int, input().split(' '))))
sum_prim_diag = 0
for i in range(n):
    sum_prim_diag += matrix[i][i]
print(sum_prim_diag)