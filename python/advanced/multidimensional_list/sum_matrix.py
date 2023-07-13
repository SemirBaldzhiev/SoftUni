row, col = list(map(int, input().split(', ')))
matrix = []

for _ in range(row):
    matrix.append(list(map(int, input().split(', '))))

sum_matrix = 0
for i in range(row):
    for j in range(col):
        sum_matrix+=matrix[i][j]
print(sum_matrix)
print(matrix)   