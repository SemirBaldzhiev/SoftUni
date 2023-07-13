row, col = list(map(int, input().split(', ')))
matrix = []

for _ in range(row):
    matrix.append(list(map(int, input().split(' '))))

for i in range(col):
    sum_col = 0
    for j in range(row):
        sum_col+=matrix[j][i]
    print(sum_col)