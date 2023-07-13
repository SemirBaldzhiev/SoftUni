film_budget = float(input())
cnt_stat = int(input())
price_obl = float(input())

price_obl = cnt_stat * price_obl

if cnt_stat > 150:
    price_obl -= price_obl*0.1


film_price = film_budget*0.1 + price_obl

if film_price > film_budget:
    print('Not enough money!')
    print(f'Wingard needs {(film_price - film_budget):.2f} leva more.')
else:
    print('Action!')
    print(f'Wingard starts filming with {(film_budget - film_price):.2f} leva left.')
