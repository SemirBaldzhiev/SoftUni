n = int(input())
total_price = 0
for i in range(0, n):
    price_per_capsule = float(input())
    days = int(input())
    capsule_per_day = int(input())
    if days < 1 or days > 31: continue
    if price_per_capsule < 0.01 or price_per_capsule > 100: continue
    if capsule_per_day < 1 or capsule_per_day > 2000: continue
    order_price = capsule_per_day * price_per_capsule * days
    total_price += order_price
    print(f'The price for the coffee is: ${order_price:.2f}')

print(f'Total: ${total_price:.2f}')