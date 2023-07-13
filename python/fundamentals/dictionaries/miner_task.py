resources = {}
while True:
    resource = input()
    if resource == 'stop': break
    quantity = int(input())
    if resource in resources:
        resources[resource] += quantity
    else:
        resources[resource] = quantity

for key in resources:
    print(f'{key} -> {resources[key]}')