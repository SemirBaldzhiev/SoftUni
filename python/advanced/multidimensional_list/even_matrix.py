row = int(input())
matrix = []
for _ in range(row):
    matrix.append(list(map(int, input().split(', '))))

print([[x for x in matrix[i] if x % 2 == 0] for i in range(row)])