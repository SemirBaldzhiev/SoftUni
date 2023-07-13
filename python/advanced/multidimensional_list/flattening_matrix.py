row = int(input())
matrix = []
for _ in range(row):
    matrix.append(list(map(int, input().split(', '))))

print([x for sublist in matrix for x in sublist])   