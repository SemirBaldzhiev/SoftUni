countries = list(input().split(', '))
capitals = list(input().split(', '))

dic = {country: capital for (country, capital) in zip(countries, capitals) }
for key in dic:
    print(f'{key} -> {dic[key]}')