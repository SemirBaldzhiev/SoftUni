pens_cnt = int(input())
marker_cnt = int(input())
preparat_litri = int(input())
perc_disc = int(input())

price = pens_cnt * 5.8 + marker_cnt * 7.2 + preparat_litri * 1.2
price -= price * (perc_disc/100)
print(price)