price_eks = float(input())
puzel_cnt = int(input())
kukli_cnt = int(input())
mecheta_cnt = int(input())
minion_cnt = int(input())
kamion_cnt = int(input())

cnt_igrachki = puzel_cnt + kukli_cnt + mecheta_cnt + minion_cnt + kamion_cnt
final_price = puzel_cnt * 2.6 + kukli_cnt * 3 + mecheta_cnt * 4.1 + minion_cnt * 8.2 + kamion_cnt*2

if cnt_igrachki >= 50:
    final_price -= final_price*0.25

final_price -= final_price*0.1

if final_price >= price_eks:
    print(f'Yes! {(final_price - price_eks):.2f} lv left.')
else:
    print(f'Not enough money! {(price_eks - final_price):.2f} lv needed.')