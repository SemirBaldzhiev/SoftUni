def smallest(a, b, c):
    return min(a, min(b, c))

a = int(input())
b = int(input())
c = int(input())

print(smallest(a, b, c))