numbers = list(map(int, input().split(',')))

obj = {
    'positive': [x for x in numbers if x >= 0],
    'negative': [x for x in numbers if x < 0],
    'even': [x for x in numbers if x%2==0],
    'odd': [x for x in numbers if x%2!=0]
}

print('Positive: {positive}\nNegative: {negative}\nEven: {even}\nOdd: {odd}'.format_map(obj))