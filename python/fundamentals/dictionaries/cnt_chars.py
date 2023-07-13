text = input()
dic = {}

for c in text:
    if c == ' ': continue
    if c in dic: dic[c] +=1
    else: dic[c] = 1

for key in dic:
    print(f'{key} -> {dic[key]}')