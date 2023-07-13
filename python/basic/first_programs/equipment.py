year_tax = int(input())

price = year_tax
year_tax -= year_tax*0.4
price += year_tax
year_tax -= year_tax*0.2
price += year_tax
year_tax /= 4
price += year_tax
year_tax /= 5
price += year_tax
print(price)