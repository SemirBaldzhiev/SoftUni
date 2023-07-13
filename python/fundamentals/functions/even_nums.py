numbers = [int(x) for x in input().split(' ')]
even_nums_iter = filter(lambda x: (x%2==0), numbers)
even_nums = list(even_nums_iter)
print(even_nums)