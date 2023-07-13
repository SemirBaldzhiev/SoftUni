chicken_menu_cnt = int(input())
fish_menu_cnt = int(input())
vegan_menu_cnt = int(input())

price = chicken_menu_cnt * 10.35 + fish_menu_cnt * 12.4 + vegan_menu_cnt * 8.15
price += price * 0.2
price += 2.5
print(price)