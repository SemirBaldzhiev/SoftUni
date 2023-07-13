def sum_numbers(a, b):
    return a+b

def subtract(a, b):
    return a-b
def add_and_subtract(a, b, c):
    print(subtract(sum_numbers(a, b), c))

a = int(input())
b = int(input())
c = int(input())
add_and_subtract(a, b, c)