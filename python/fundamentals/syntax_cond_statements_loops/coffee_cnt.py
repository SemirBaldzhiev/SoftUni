coffee_cnt = 0
events = ['coding', 'dog', 'cat', 'movie', 'CODING', 'DOG', 'CAT', 'MOVIE', 'END']
while True:
    event = input()
    cnt = events.count(event)
    if cnt == 0: continue
    if event == 'END': break
    if event.isupper():
        coffee_cnt+=2
    else:
        coffee_cnt+=1
if coffee_cnt > 5:
    print('You need extra sleep')
else:
    print(coffee_cnt)