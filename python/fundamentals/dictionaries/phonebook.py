phonebook = dict()
n = 0

while True:
    entry = input()
    if entry.isnumeric(): 
        n = int(entry)
        break
    (name, phone) = entry.split('-')
    phonebook[name] = phone

for i in range(0, n):
    search_name = input()
    if search_name in phonebook:
        print(f'{search_name} -> {phonebook[search_name]}')
    else:
        print(f'Contact {search_name} does not exist.')